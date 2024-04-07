using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    private PhotonView photonView;

    GameObject myXrOrigin;
    private InputData inputData;

    void Start()
    {
        myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        inputData = myXrOrigin.GetComponent<InputData>();
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);
        }
        MapPosition(leftHand, inputData.leftController);
        MapPosition(rightHand, inputData.rightController);
    }

    void MapPosition(Transform target, InputDevice device)
    {
        device.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        device.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = this.gameObject.transform.position + position;
        target.rotation = rotation;
    }
}