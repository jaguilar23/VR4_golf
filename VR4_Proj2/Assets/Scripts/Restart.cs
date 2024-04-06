using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    GameObject myXrOrigin;

    private InputData inputData;
    public GameObject ballSpawn;

    private LogisticsManager myLogistics;

    // Restart confirmation text
    //erializeField] GameObject yesBtn;
    //[SerializeField] GameObject noBtn;
    //[SerializeField] GameObject restartConfirm;

    //private TextMeshProUGUI restartConfirm;
   // public Button yesBtn;
   // private Button noBtn;
   

  
    

    private void Start()
    {
        myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        inputData = myXrOrigin.GetComponent<InputData>();
        // yesBtn = GameObject.Find("Yes_Btn").GetComponent<Button>();
        GameObject logistics = GameObject.Find("LogisticsManager");
        myLogistics = logistics.GetComponent<LogisticsManager>();
    }

    void Update()
    {
        
        
        
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool t_pressed))
        {
            /** 
             * 
            if (t_pressed && myLogistics.restartButtonPressed)
            {
                Debug.Log("button pressed");
                teleportBall();
                Debug.Log("ball moved");

                myLogistics.restartButtonPressed = false;
            }
             */
        }
        
        if (myLogistics.restartButtonPressed)
        {
            teleportBall();
            Debug.Log("ball moved");

            myLogistics.restartButtonPressed = false;
        }
    }

    public void teleportBall()
    {
        transform.position = ballSpawn.gameObject.transform.position;
        gameObject.GetComponent<BallManager>().stopMove();
    }
}
