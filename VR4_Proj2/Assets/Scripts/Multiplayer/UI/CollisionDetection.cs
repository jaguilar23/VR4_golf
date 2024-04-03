using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public bool collided = false;

    private void OnCollisionEnter(Collision collision)
    {
        collided = true;
    }
}
