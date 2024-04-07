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
    [SerializeField] private int[] scores = new int[3];  // for scoreboard
    [SerializeField] private TextMeshProUGUI[] coursesScoreText = new TextMeshProUGUI[3]; // text for scoreboard
    [SerializeField] private TextMeshProUGUI totalScore;
    //private string scoreText = "Current score: ";

    public bool collisionFound = false;

    public GameObject playerObject;
    public int playerID;

    public GameObject myBall;          // player's ball

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
    }

    public void setPlayerObj(GameObject obj) { playerObject = obj; }
    public void setBall(GameObject ball) { myBall = ball; }

    public void setPlayerID()
    {
        // set playerID based on players on server
        var numPlayers = GameObject.FindGameObjectsWithTag("Player");

        playerID = numPlayers.Length;
    }

    public void restartToggle()
    {
        restartButtonPressed = true;
    }

    public void Island1()
    {
        // teleport
        playerObject.transform.position = Lvl1.gameObject.transform.position;
        currentCourse = 1;
    }

    public void Island2()
    {
        // teleport
        playerObject.transform.position = Lvl2.gameObject.transform.position;
        currentCourse = 2;
    }

    public void Island3()
    {
        // teleport
        playerObject.transform.position = Lvl3.gameObject.transform.position;
        currentCourse = 3;
    }

    public void setScore(int num)
    {
        // what
        coursesScoreText[currentCourse - 1].text = "Level " + currentCourse.ToString() + ": " + num.ToString();
    }

    public void finalizeScore()
    {
        // what
        scores[currentCourse - 1] = myBall.transform.GetChild(0).GetComponent<BallManager>().numHits;
        coursesScoreText[currentCourse - 1].text = "Level " + currentCourse.ToString() + ": " + scores[currentCourse - 1].ToString();

        int count = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            count += scores[0];
        }

        totalScore.text = "Total score: " + count.ToString();
    }


}
