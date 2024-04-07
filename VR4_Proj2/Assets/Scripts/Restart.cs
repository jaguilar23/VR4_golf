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
    public GameObject ballSpawn_Lvl2;
    public GameObject ballSpawn_Lvl3;

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
        // restart ball to level 1
        if (myLogistics.restartButtonPressed && myLogistics.currentCourse == 1)
        {
            teleportBall();
            Debug.Log("ball moved");

            myLogistics.restartButtonPressed = false;
        }

        // restart ball to level 2
        if (myLogistics.restartButtonPressed && myLogistics.currentCourse == 2)
        {
            teleportBall2();
            Debug.Log("ball moved");

            myLogistics.restartButtonPressed = false;
        }

        // restart ball to level 3
        if (myLogistics.restartButtonPressed && myLogistics.currentCourse == 3)
        {
            teleportBall3();
            Debug.Log("ball moved");

            myLogistics.restartButtonPressed = false;
        }
    }

    public void teleportBall()
    {
        transform.position = ballSpawn.gameObject.transform.position;
        gameObject.GetComponent<BallManager>().stopMove();
    }

    public void teleportBall2()
    {
        transform.position = ballSpawn_Lvl2.gameObject.transform.position;
        gameObject.GetComponent<BallManager>().stopMove();
    }
    public void teleportBall3()
    {
        transform.position = ballSpawn_Lvl3.gameObject.transform.position;
        gameObject.GetComponent<BallManager>().stopMove();
    }
}
