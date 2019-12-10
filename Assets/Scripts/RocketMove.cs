using UnityEngine;

public class RocketMove : MonoBehaviour
{
    public Vector3 TargetPosition;
    public float MoveTimeSpeed = 1;
    public int Damage;
    private Vector2 _startPos;
    private float _localtimer = 0;
    private bool _onTarget;

    void Start()
    {
        _startPos = transform.position;
        _onTarget = false;
    }

    void Update()
    {
        if (!_onTarget)
        {
            _localtimer += Time.deltaTime;
            transform.position = Vector2.Lerp(_startPos, TargetPosition, _localtimer / MoveTimeSpeed);
            if (_localtimer >= 1)
            {
                transform.position = TargetPosition;
                _onTarget = true;
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