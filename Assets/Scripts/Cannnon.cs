using UnityEngine;

public class Cannnon : MonoBehaviour
{
    public GameObject currentProjectille;
    public Camera CameraMain;
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
                bullet.GetComponent<RocketMove>().TargetPosition = mousePosition;
                bullet.GetComponent<RocketMove>().Damage = Damge;
                shootDelayCounter = 0;
            }
        }
    }
    private Vector3 mousePosition;
    void RotateToClick()
    {
        mousePosition = CameraMain.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z += 20;
    }
}