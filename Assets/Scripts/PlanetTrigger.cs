using UnityEngine;
using System.Collections;
using TMPro;


public class PlanetTrigger : MonoBehaviour
{
    public PlanetAi  twr;
    public bool lockE;
    public GameObject curTarget;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            curTarget = null;
            other = null;
        }
        if (other != null && !lockE)
        {
            twr.target = other.gameObject.transform;
            curTarget = other.gameObject;
            lockE = true;
        }
    }
    void Update()
    {
        if (!curTarget)
        {
            lockE = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject == curTarget)
        {
            lockE = false;
        }
    }
}