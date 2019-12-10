using System.Collections.Generic;
using UnityEngine;

internal class MagnetAll : MonoBehaviour
{
    List<MagnetizedObject> ListMagnetticObj;
    public float Range;
    public float Strength;

    public void Start()
    {
        ListMagnetticObj = new List<MagnetizedObject>();
        gameObject.GetComponent<SphereCollider>().radius = Range;
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
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            MagnetizedObject newMag = new MagnetizedObject();
            newMag.Col = other;
            newMag.Rb = other.GetComponent<Rigidbody>();
            newMag.Trans = other.transform;
            newMag.Polarity = 1;
            ListMagnetticObj.Add(newMag);
        }
        else if (other.gameObject.CompareTag("Sun"))
        {
            MagnetizedObject newMag = new MagnetizedObject();
            newMag.Col = other;
            newMag.Rb = other.GetComponent<Rigidbody>();
            newMag.Trans = other.transform;
            newMag.Polarity = -1;
            ListMagnetticObj.Add(newMag);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Sun"))
        {
            for (int i = 0; i < ListMagnetticObj.Count; i++)
            {
                if (ListMagnetticObj[i].Col == other)
                {
                    ListMagnetticObj.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private void ApplyMagneticForce(MagnetizedObject obj)
    {
        Vector3 rawDirection = transform.position - obj.Trans.position;
        float distance = rawDirection.magnitude;
        float distanceScale = Mathf.InverseLerp(Range, 0f, distance);
        float attractionStrength = Mathf.Lerp(0f, Strength, distanceScale);
        obj.Rb.AddForce(rawDirection.normalized * attractionStrength * obj.Polarity, ForceMode.Force);
    }
}

public class MagnetizedObject
{
    public Collider Col;
    public Rigidbody Rb;
    public Transform Trans;
    public int Polarity;
}