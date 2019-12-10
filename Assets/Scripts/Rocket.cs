using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float Speed = 4;
    public Transform target;
    public PlanetAi PlanetT;
    public int Damage;

    void Update()
    {
        if (target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * Speed);

        }
        if (!target)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target.GetComponentInParent<PlanetControl>().PlayeHp -= Damage;
            Destroy(gameObject);
        }
        if (other.tag == "Sun")
        {
            Destroy(gameObject);
        }
        
    }
}
