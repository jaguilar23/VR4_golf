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

    // Restart confirmation text
    //erializeField] GameObject yesBtn;
    //[SerializeField] GameObject noBtn;
    //[SerializeField] GameObject restartConfirm;

    //private TextMeshProUGUI restartConfirm;
    public Button yesBtn;
   // private Button noBtn;
   

  
    

    private void Start()
    {
        myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        inputData = myXrOrigin.GetComponent<InputData>();
        yesBtn = GameObject.Find("Yes_Btn").GetComponent<Button>();
    }

    void Update()
    {
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool t_pressed))
        {
            if (t_pressed)
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
