using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine;

public class MultiplayerMovement : MonoBehaviour
{
    private float xInput;
    private float zInput;
    public float movementSpeed = 5.0f;

    private InputData inputData;
    GameObject myXrOrigin;
    private Rigidbody myRB;         // player rigidbody
    private Transform myXRRig;      // XR headset rigidbody


    // System vars
    bool grounded;
    public LayerMask groundedMask;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        myRB = GetComponent<Rigidbody>();
        myXRRig = myXrOrigin.transform;
        inputData = myXrOrigin.GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        myXRRig.position = transform.position + transform.up;
        //myXRRig.rotation = transform.rotation;

        // fetching 2D joystick input
        if (inputData.leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 movement))
        {
            xInput = movement.x;
            zInput = movement.y;
        } else
        {
            xInput = Input.GetAxis("Horizontal");
            zInput = Input.GetAxis("Vertical");
        }

        // Smoothed xz-movement
        Vector3 moveDir = new Vector3(xInput, 0, zInput).normalized;
        Vector3 targetMoveAmount = moveDir * movementSpeed;
        moveAmount = Vector3.SmoothDamp(movement, targetMoveAmount, ref smoothMoveVelocity, 0.15f);

        // Ground check
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        // rotate with XR
        GameObject cameraTransform = myXrOrigin.transform.GetChild(0).GetChild(0).gameObject;
        Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, myXRRig.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Euler(eulerRotation);

        grounded = (Physics.Raycast(ray, out hit, 1 + 0.1f, groundedMask)) ? true : false;
    }

    private void FixedUpdate()
    {
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        myRB.MovePosition(myRB.position + localMove);
    }
}
