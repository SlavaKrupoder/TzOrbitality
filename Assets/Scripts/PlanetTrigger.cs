using UnityEngine;
using System.Collections;
using TMPro;

public class PlanetTrigger : MonoBehaviour
{
    public PlanetAi  PlAi;
    private bool _lockE;
    public GameObject curTarget;

    void OnTriggerEnter(Collider other)
    {
        if (other != null && !_lockE && other.tag == "Player")
        {
            PlAi.target = other.gameObject.transform;
            curTarget = other.gameObject;
            _lockE = true;
        }
    }
    void Update()
    {
        if (!curTarget)
        {
            _lockE = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other != null || other.gameObject == curTarget)
        {
            _lockE = false;
        }
    }
}