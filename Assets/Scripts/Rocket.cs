using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float Speed = 4;
    public Transform Target;
    public PlanetAi PlanetT;
    public int Damage;

    void Update()
    {
        if (Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * Speed);

        }
        if (!Target)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Target.GetComponentInParent<PlanetControl>().PlayeHp -= Damage;
            Destroy(gameObject);
        }
        if (other.tag == "Sun")
        {
            Destroy(gameObject);
        }
    }
}