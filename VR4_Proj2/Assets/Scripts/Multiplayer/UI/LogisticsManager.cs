using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogisticsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI myCurrentScoreText;

    [SerializeField] public int currentCourse = 1;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int[] scores = new int[3];  // for scoreboard
    private string scoreText = "Current score: ";

    public bool collisionFound = false;

    private GameObject playerObject;
    public int playerID;

    [Header("Player Device Hands")]
    public GameObject leftHand;
    public GameObject rightHand;

    private GameObject myPutter;        // player's putter
    private GameObject myBall;          // player's ball

    public bool restartButtonPressed = false;

    // teleport spawners
    public GameObject Lvl1;
    public GameObject Lvl2;
    public GameObject Lvl3;

    [SerializeField] public Material[] ballColors = new Material[4];

    [Header("Golf Club Spawn Locations")]
    [SerializeField] private GameObject[] putterSpawnLocations = new GameObject[4]; // four locations a putter can be instantiated

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionFound)
        {
            currentScore++;
            myCurrentScoreText.text = scoreText + currentScore.ToString();

            collisionFound = false;
        }
    }

    public void setPlayerObj(GameObject obj) { playerObject = obj; }
    public void setPutter(GameObject putter) { myPutter = putter; }
    public void setBall(GameObject ball) { myBall = ball; }

    public void setPlayerID()
    {
        // set playerID based on players on server
        var numPlayers = GameObject.FindGameObjectsWithTag("Player");

        playerID = numPlayers.Length + 1;
    }

    public void restartToggle()
    {
        restartButtonPressed = true;
    }

    public void Island1()
    {
        // teleport
        playerObject.transform.position = Lvl1.gameObject.transform.position;
    }

    public void Island2()
    {
        // teleport
        playerObject.transform.position = Lvl2.gameObject.transform.position;
    }

    public void Island3()
    {
        // teleport
        playerObject.transform.position = Lvl3.gameObject.transform.position;
    }
}
