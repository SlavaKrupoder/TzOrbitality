using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class PlanetAi : MonoBehaviour
{
    public GameObject RocketShootZona;
    public UserDataSave DataSavePlanet;
    public GameObject Rocket;
    public Transform shootElement;
    public Transform LookAtObj;
    public Transform target;
    private float _shootDelay;
    private float _speedRot;
    public int HpPlanet;
    bool isShoot;

    private void Start()
    {
        _speedRot = DataSavePlanet.Speed;
        HpPlanet = DataSavePlanet.Hp;
        _shootDelay = DataSavePlanet.ShoodDelay;
    }

    void Update()
    {
        if (target)
        {
            if (target.tag =="Player")
            {
                LookAtObj.transform.LookAt(target);
                if (!isShoot)
                {
                    StartCoroutine(shoot());
                }
            }
            else
            {
                target = null;
            }
        }
        this.transform.Rotate(new Vector3(0, 0, _speedRot));
        if(HpPlanet <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadData(Save.PlaetSaveData saveData)
    {
        this.transform.Rotate(new Vector3(0, 0, saveData.RotationPosition));
        HpPlanet = saveData.HpPlanet;
    }

    IEnumerator shoot()
    {
        isShoot = true;
        yield return new WaitForSeconds(_shootDelay);
        GameObject b = Instantiate(Rocket, shootElement.position, Quaternion.identity) as GameObject;
        Rocket.gameObject.GetComponent<Rocket>().Damage = DataSavePlanet.Damage;
        b.GetComponent<Rocket>().Target = target;
        b.GetComponent<Rocket>().PlanetT = this;
        isShoot = false;
    }
}