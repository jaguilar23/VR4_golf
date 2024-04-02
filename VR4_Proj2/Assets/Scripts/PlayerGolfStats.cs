using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentState { CLUB, BALL }
public class PlayerGolfStats : MonoBehaviour
{
    public int currentCourse = 1;
    int[] scores = new int[3];  // for scoreboard

    GameObject putterSpawnSpot;
    GameObject ballSpawnSpot;

    public GameObject playerPutter;
    public GameObject playerBall;

    // Start is called before the first frame update
    void Start()
    {
        putterSpawnSpot = GameObject.Find("PutterSpawnSpots").gameObject.transform.GetChild(0).gameObject;
        ballSpawnSpot = GameObject.Find("BallSpawnSpots").gameObject.transform.GetChild(currentCourse - 1).gameObject; // spawns ball by currentCourse

        Instantiate(playerPutter, putterSpawnSpot.transform.position, putterSpawnSpot.transform.rotation); // instantiate putter at putterSpawnSpot (table)
        Instantiate(playerBall, ballSpawnSpot.transform.position, Quaternion.identity); // instantiate golf ball at ballSpawnSpot
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
