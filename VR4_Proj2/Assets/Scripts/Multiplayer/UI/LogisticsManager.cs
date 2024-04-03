using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogisticsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI myCurrentScoreText;

    [SerializeField] int currentCourse = 1;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int[] scores = new int[3];  // for scoreboard
    private string scoreText = "Current score: ";

    public bool collisionFound = false;

    public int playerID;

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

    public void setPlayerID()
    {
        // set playerID based on players on server
        var numPlayers = GameObject.FindGameObjectsWithTag("Player");

        playerID = numPlayers.Length + 1;
    }
}
