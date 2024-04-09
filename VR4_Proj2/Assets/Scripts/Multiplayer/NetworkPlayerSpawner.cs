using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    [Header("Personal Putter and Ball")]
    GameObject putterSpawnSpot;
    GameObject ballSpawnSpot;

    private GameObject spawnedPlayerObject;
    //private GameObject spawnedPutterObject;
    private GameObject spawnedBallObject;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        // fetch putter and ball spots
        putterSpawnSpot = GameObject.Find("PutterSpawnSpots").gameObject.transform.GetChild(0).gameObject;
        ballSpawnSpot = GameObject.Find("BallSpawnSpots").gameObject.transform.GetChild(0).gameObject; // spawns ball by currentCourse

        spawnedPlayerObject = PhotonNetwork.Instantiate("NetworkPlayer", transform.position, transform.rotation);
        spawnedPlayerObject.name = "Player" + PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        //spawnedPlayerObject.transform.GetChild(0).name = "Player" + PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        //spawnedPutterObject = PhotonNetwork.Instantiate("NetworkPutter", putterSpawnSpot.transform.position, putterSpawnSpot.transform.rotation);
        spawnedBallObject = PhotonNetwork.Instantiate("NetworkBall", ballSpawnSpot.transform.position, Quaternion.identity);
        spawnedBallObject.name = "Ball" + PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        //spawnedBallObject.transform.GetChild(0).name = "Ball" + PhotonNetwork.LocalPlayer.ActorNumber.ToString();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerObject);
        //PhotonNetwork.Destroy(spawnedPutterObject);
        PhotonNetwork.Destroy(spawnedBallObject);
    }
}