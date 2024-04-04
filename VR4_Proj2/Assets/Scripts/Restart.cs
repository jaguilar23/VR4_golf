using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Restart : MonoBehaviour
{
    GameObject myXrOrigin;

    private InputData inputData;
    public GameObject ballSpawn;

    private void Start()
    {
        myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        inputData = myXrOrigin.GetComponent<InputData>();
    }

    void Update()
    {
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool a_pressed))
        {
            if (a_pressed)
            {
                Debug.Log("button pressed");
                teleportBall();
                Debug.Log("ball moved");

            }
        }
    }

    public void teleportBall()
    {
        transform.position = ballSpawn.gameObject.transform.position;
    }
}
