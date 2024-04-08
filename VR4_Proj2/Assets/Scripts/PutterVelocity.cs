using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutterVelocity : MonoBehaviour
{
    public Vector3 vel;
    private Vector3 prevPos;

    public float forceMultiplier;

    private void Start()
    {
        prevPos = transform.position;

        forceMultiplier = 1.15f;
    }

    // Update is called once per frame
    void Update()
    {
        vel = (transform.position - prevPos) / Time.deltaTime;
        vel *= forceMultiplier;
        prevPos = transform.position;
    }
}
