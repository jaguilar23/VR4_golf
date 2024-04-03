using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;


public class PutterManager : MonoBehaviour
{

    private CollisionDetection myColDec;
    private LogisticsManager myLogistics;

    private PhotonView myView;
    private GameObject myChild;


    // Start is called before the first frame update
    void Start()
    {
        myView = GetComponentInParent<PhotonView>();

        GameObject logistics = GameObject.Find("LogisticsManager");
        myLogistics = logistics.GetComponent<LogisticsManager>();

        myColDec = myChild.GetComponent<CollisionDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myView.IsMine)
        {
            if (myColDec.collided)
            {
                // do something because I collided
                myLogistics.collisionFound = true;
                myColDec.collided = false;
            }
        }
    }
}
