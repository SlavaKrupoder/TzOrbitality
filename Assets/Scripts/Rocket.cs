using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public float Speed = 0.05f;
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
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (other.tag == "End")
        {
            Destroy(gameObject);
        }
    }
}
