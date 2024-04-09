using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LogisticsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI myCurrentScoreText;

    [SerializeField] public int currentCourse = 1;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private TextMeshProUGUI[] coursesScoreText = new TextMeshProUGUI[3]; // text for scoreboard
    [SerializeField] private int[] scores = new int[3];  // for scoreboard
    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private TextMeshProUGUI winText;
    //private string scoreText = "Current score: ";

    public bool collisionFound = false;
    bool isFinished = false; // check if game is finished

    public GameObject playerObject;
    public int playerID;

    public GameObject myBall;          // player's ball

    public bool restartButtonPressed = false;

    // teleport spawners
    public GameObject Lvl1;
    public GameObject Lvl2;
    public GameObject Lvl3;

    [SerializeField] public Material[] ballColors = new Material[3];
    [SerializeField] public Material[] playerColors = new Material[3];

    [Header("Golf Club Spawn Locations")]
    [SerializeField] private GameObject[] putterSpawnLocations = new GameObject[4]; // four locations a putter can be instantiated

    // Start is called before the first frame update
    void Start()
    {
        // Fetches score canvas text
        //GameObject myXrOrigin = GameObject.Find("XR Origin (XR Rig)");
        //scoreText = myXrOrigin.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collisionFound)
        {
            currentScore++;
            //myCurrentScoreText.text = scoreText + currentScore.ToString();

            collisionFound = false;
        }

        foreach (int score in scores)
        {
            if (score == 0)
            {
                isFinished = false;
                break;
            } else
            {
                isFinished = true;
            }
        }

        if (isFinished)
        {
            winText.gameObject.SetActive(true);
        }
    }

    public void setPlayerObj(GameObject obj) { playerObject = obj; }
    public void setBall(GameObject ball) { myBall = ball; }

    public void setPlayerID()
    {
        // set playerID based on players on server
        //var numPlayers = GameObject.FindGameObjectsWithTag("Player");

        //playerID = numPlayers.Length;
    }

    public void restartToggle()
    {
        restartButtonPressed = true;
    }

    public void newIslandToggle()
    {
        restartButtonPressed = true;
        myBall.GetComponent<BallManager>().numHits = 0;
    }

    public void Island1()
    {
        // teleport
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < players.Length; i++)
        {
        }
        if (playerObject != null)
        {
            playerObject.transform.position = Lvl1.gameObject.transform.position;
            currentCourse = 1;
            restartButtonPressed = true;
        }
    }

    public void Island2()
    {
        // teleport
        if (playerObject != null)
        {
            playerObject.transform.position = Lvl2.gameObject.transform.position;
            currentCourse = 2;
            restartButtonPressed = true;
        }
    }

    public void Island3()
    {
        if (playerObject != null)
        {
            // teleport
            playerObject.transform.position = Lvl3.gameObject.transform.position;
            currentCourse = 3;
            restartButtonPressed = true;
        }
    }

    public void setScore(int num)
    {
        // what
        coursesScoreText[currentCourse - 1].text = "Level " + currentCourse.ToString() + ": " + num.ToString();
    }

    public void finalizeScore()
    {
        // what
        scores[currentCourse - 1] = myBall.GetComponent<BallManager>().numHits;
        coursesScoreText[currentCourse - 1].text = "Level " + currentCourse.ToString() + ": " + scores[currentCourse - 1].ToString();

        int count = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            count += scores[i];
        }

        totalScore.text = "Total: " + count.ToString();
    }


}
