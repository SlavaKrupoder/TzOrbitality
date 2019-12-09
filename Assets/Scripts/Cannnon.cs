using UnityEngine;

public class Cannnon : MonoBehaviour
{
    public GameObject currentProjectille;
    public int Damge;
    public float shootDelay;
    public Transform shootPostion; 
    protected float shootDelayCounter;
    private Rigidbody myRigidbody;

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        shootDelayCounter += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            RotateToClick();

            if (shootDelayCounter >= shootDelay)
            {
                var bullet = Instantiate(currentProjectille, shootPostion.position, shootPostion.rotation);
                bullet.GetComponent<BulletMove>().targetPosition = mousePosition;
                bullet.GetComponent<BulletMove>().Damage = Damge;
                shootDelayCounter = 0;
            }
        }
    }

    private Vector3 mousePosition;

    private float angle;

    void RotateToClick()
    {
        //позиция мыши в мировых координатах
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 20;

        // Угол между объектами
        angle = Vector2.Angle(Vector2.right, mousePosition - transform.position); //угол между вектором от объекта к мыше и осью х

        // Мгновенное вращение
        //transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);

        // Вращение с задержкой (не успеет повернуться, если в направлении клика стрелять)
        // transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.Euler (0, 0, transform.position.y < mousePosition.y ? angle : -angle), RotateSpeed * Time.deltaTime);
    }

}