using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetControl : MonoBehaviour
{
    [SerializeField]
    private GameObject Planet;
    [SerializeField]
    private Cannnon PlayerCanon;
    [SerializeField]
    private GameObject PlanetObj;
    [SerializeField]
    private UserDataSave PlayerSettings;
    public int PlayeHp;
    private float _speedRotate;

    private void Start()
    {
        PlayerCanon.Damge = PlayerSettings.Damage;
        PlayeHp = PlayerSettings.Hp;
        _speedRotate = PlayerSettings.Speed;
    }
    void Update()
    {
        var x = PlanetObj.transform.localPosition.x;
        if (Input.GetKeyDown(KeyCode.A))
        {
            Planet.transform.Rotate(new Vector3(0, 0, _speedRotate));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Planet.transform.Rotate(new Vector3(0, 0, -_speedRotate));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (x >= -8 && x<0) 
            {
                PlanetObj.transform.localPosition = (new Vector3(x + 2.0f, 0, 0));
            }
            else
            {
                x = -8;
                PlanetObj.transform.localPosition = (new Vector3(x, 0, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (x <= -2 && x > -10)
            {
                PlanetObj.transform.localPosition = (new Vector3(x - 2.0f, 0, 0));
            }
            else
            {
                x = -2;
                PlanetObj.transform.localPosition = (new Vector3(x, 0, 0));
            }
        }
        if (PlayeHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
