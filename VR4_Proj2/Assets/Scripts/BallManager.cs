using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class BallManager : MonoBehaviour
{
    public int putterLayer;
    public int ballLayer;               // ball can be hit by putter in this layer
    private int movingBallLayer = 15;   // ball can't be hit again while moving in this layer
    private Rigidbody rb;
    public int numHits = 0; // number of times the ball was hit
    
    private PhotonView myView;

    private LogisticsManager myLogistics;

    private bool isMoving = false;

    private AudioSource ballAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        putterLayer = LayerMask.NameToLayer("Putter1");
        rb = GetComponent<Rigidbody>();
        myView = GetComponentInParent<PhotonView>();

        GameObject logistics = GameObject.Find("LogisticsManager");
        myLogistics = logistics.GetComponent<LogisticsManager>();
        ballAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Check if ball is moving and is extremely slow
        if (isMoving && rb.velocity.magnitude < 0.25f)
        {
            stopMove();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Debug.Log("Collision speed: " + collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
        }
        
        // check if the ball isn't moving and came into contact with the putter
        if (!isMoving && collision.gameObject.layer == putterLayer)
        {
            // speed of the putter upon contact
            //Vector3 putterVelocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            Vector3 putterVelocity = collision.gameObject.transform.GetChild(1).GetComponent<PutterVelocity>().vel;

            // check if the putter's force is powerful enough
            if (putterVelocity.magnitude > 0.3f)
            {
                setMove(putterVelocity);
            }
        }
    }
    
    void setMove(Vector3 vel)
    {
        this.gameObject.layer = movingBallLayer;
        rb.constraints = RigidbodyConstraints.None; // Allow the ball to freely move
        rb.velocity = vel;  // Set the ball's velocity the same as the putter upon contact
        numHits++;          // Increment the total number of hits by 1
        myLogistics.setScore(numHits);

        isMoving = true;

        ballAudioSource.Play();
    }

    public void stopMove()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;    // Freeze ball in place

        this.gameObject.layer = ballLayer;

        isMoving = false;
    }

    public void setLayer(LayerMask layer)
    {
        putterLayer = layer;
    }
}
