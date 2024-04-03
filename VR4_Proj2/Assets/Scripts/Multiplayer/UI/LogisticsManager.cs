using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogisticsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI myCurrentScoreText;

    [SerializeField] private int currentScore = 0;
    private string scoreText = "Current score: ";

    public bool collisionFound = false;

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
}
