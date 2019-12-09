using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public Vector3 targetPosition;

    public float MoveTimeSpeed = 1;
    public int Damage;

    private Vector2 startPos;

    float t = 0;

    bool onTarget;

    void Start()
    {
        startPos = transform.position;
        onTarget = false;
    }

    void Update()
    {
        if (!onTarget)
        {
            t += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, targetPosition, t / MoveTimeSpeed);
            if (t >= 1)
            {
                transform.position = targetPosition;
                onTarget = true;
                t = 0;
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sun")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponentInParent<PlanetAi>().HpPlanet -=Damage;
            Destroy(gameObject);
        }
        if (other.tag == "End")
        {
            Destroy(gameObject);
        }
    }
}