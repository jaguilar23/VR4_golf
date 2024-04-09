using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameEndManager : MonoBehaviourPunCallbacks
{
    public GameObject[] players;
    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        players = new GameObject[PhotonNetwork.PlayerList.Length];
        for (int i = 0; i < players.Length; i++)
        {
            int actorNum = PhotonNetwork.PlayerList[i].ActorNumber;
            players[i] = PhotonView.Find(actorNum).gameObject;
        }

        foreach (var p in players)
        {
            
        }
    }
}
