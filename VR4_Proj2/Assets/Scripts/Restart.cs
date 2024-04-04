using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Restart : MonoBehaviour
{

    private InputData inputData;
    public GameObject ballSpawn;
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
