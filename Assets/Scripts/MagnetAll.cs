using System.Collections.Generic;
using UnityEngine;

internal class MagnetAll : MonoBehaviour
{
    List<MagnetizedObject> ListMagnetticObj;
    public float range;
    public float strength;

    public void Start()
    {
        ListMagnetticObj = new List<MagnetizedObject>();
        gameObject.GetComponent<SphereCollider>().radius = range;
    }

    public void FixedUpdate()
    {
        for (int i = 0; i < ListMagnetticObj.Count; i++)
        {
            ApplyMagneticForce(ListMagnetticObj[i]);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sun") || other.gameObject.CompareTag("BRocket")|| other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            MagnetizedObject newMag = new MagnetizedObject();
            newMag.col = other;
            newMag.rb = other.GetComponent<Rigidbody>();
            newMag.t = other.transform;
            newMag.polarity = 1;
            ListMagnetticObj.Add(newMag);
        }
        else if (other.gameObject.CompareTag("Repel"))
        {
            MagnetizedObject newMag = new MagnetizedObject();
            newMag.col = other;
            newMag.rb = other.GetComponent<Rigidbody>();
            newMag.t = other.transform;
            newMag.polarity = -1;
            ListMagnetticObj.Add(newMag);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Attract") || other.CompareTag("Repel"))
        {
            for (int i = 0; i < ListMagnetticObj.Count; i++)
            {
                if (ListMagnetticObj[i].col == other)
                {
                    ListMagnetticObj.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private void ApplyMagneticForce(MagnetizedObject obj)
    {
        Vector3 rawDirection = transform.position - obj.t.position;
        float distance = rawDirection.magnitude;
        float distanceScale = Mathf.InverseLerp(range, 0f, distance);
        float attractionStrength = Mathf.Lerp(0f, strength, distanceScale);
        obj.rb.AddForce(rawDirection.normalized * attractionStrength * obj.polarity, ForceMode.Force);
    }
}

public class MagnetizedObject
{
    public Collider col;
    public Rigidbody rb;
    public Transform t;
    public int polarity;
}
