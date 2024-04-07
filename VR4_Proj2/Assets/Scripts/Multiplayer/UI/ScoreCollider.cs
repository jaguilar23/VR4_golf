using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreCollider : MonoBehaviour
{
    public ParticleSystem celebrateParticles;
    // find logistics gameobject
    private LogisticsManager myLogistics;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject logistics = GameObject.Find("LogisticsManager");
        myLogistics = logistics.GetComponent<LogisticsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            StartCoroutine(Score(other.gameObject));
        }
    }

    IEnumerator Score(GameObject ball)
    {
        celebrateParticles.Play();
        Debug.Log("SCORE!");
        myLogistics.finalizeScore();
        yield return new WaitForSeconds(5.0f);
        ball.SetActive(false);
    }
}
