using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public int putterLayer;
    private Rigidbody rb;
    public int numHits = 0; // number of times the ball was hit

    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        putterLayer = LayerMask.NameToLayer("Putter");
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Check if ball is moving and is extremely slow
        if (isMoving && rb.velocity.magnitude < 0.01f)
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
            Vector3 putterVelocity = collision.gameObject.GetComponent<Rigidbody>().velocity;
            
            // check if the putter's force is powerful enough
            if (putterVelocity.magnitude > 0.1f)
            {
                setMove(putterVelocity);
            }
        }
    }
    
    void setMove(Vector3 vel)
    {
        rb.constraints = RigidbodyConstraints.None; // Allow the ball to freely move
        rb.velocity = vel;  // Set the ball's velocity the same as the putter upon contact
        Debug.Log("Ball Hit");
        numHits++;          // Increment the total number of hits by 1
        Debug.Log("num hit increases");
        
        isMoving = true;
    }

    void stopMove()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;    // Freeze ball in place

        isMoving = false;
    }

    public void setLayer(LayerMask layer)
    {
        putterLayer = layer;
    }
}
