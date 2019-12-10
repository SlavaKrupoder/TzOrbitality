using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public Vector3 TargetPosition;
    public float MoveTimeSpeed = 1;
    public int Damage;
    private Vector2 _startPos;
    private float _localtimer = 0;

    bool onTarget;

    void Start()
    {
        _startPos = transform.position;
        onTarget = false;
    }

    void Update()
    {
        if (!onTarget)
        {
            _localtimer += Time.deltaTime;
            transform.position = Vector2.Lerp(_startPos, TargetPosition, _localtimer / MoveTimeSpeed);
            if (_localtimer >= 1)
            {
                transform.position = TargetPosition;
                onTarget = true;
                _localtimer = 0;
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