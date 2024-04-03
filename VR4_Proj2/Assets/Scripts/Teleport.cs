using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class Teleport : MonoBehaviour
{
    // Target object
    public GameObject Target;

    // Target to
    public GameObject Lvl1;
    public GameObject Lvl2;
    public GameObject Lvl3;

    public void Island1()
    {
        // teleport
        Target.gameObject.transform.position = Lvl1.gameObject.transform.position;
    }

    public void Island2()
    {
        // teleport
        Target.gameObject.transform.position = Lvl2.gameObject.transform.position;
    }

    public void Island3()
    {
        // teleport
        Target.gameObject.transform.position = Lvl3.gameObject.transform.position;
    }
}

