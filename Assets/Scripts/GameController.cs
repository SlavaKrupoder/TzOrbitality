using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject WinLoseTab;

    private bool _isPause = false;
    [SerializeField]
    private GameObject CameraMenu;
    [SerializeField]
    private GameObject CameraGame;

    [SerializeField]
    private TextMeshProUGUI YourHp;
    [SerializeField]
    private TextMeshProUGUI StatusGame;
    [SerializeField]
    private TextMeshProUGUI Planet1Hp;
    [SerializeField]
    private TextMeshProUGUI Planet2Hp;
    [SerializeField]
    private TextMeshProUGUI Planet3Hp;

    [SerializeField]
    private PlanetAi Planet3;
    [SerializeField]
    private PlanetAi Planet2;
    [SerializeField]
    private PlanetAi Planet1;
    [SerializeField]
    private PlanetControl Player;

    void Start()
    {
        Resume();
    }

    void Update()
    {
        YourHp.text = "Your HP:" + Player.PlayeHp;
        Planet1Hp.text = Planet1.HpPlanet + "/200";
        Planet2Hp.text = Planet2.HpPlanet + "/100";
        Planet3Hp.text = Planet3.HpPlanet + "/300";
        if (Player.PlayeHp <= 0)
        {
            Pause();
            WinLoseTab.SetActive(true);
            StatusGame.text = "You Lose!!!";
        }
        if (Planet1.HpPlanet <= 0 && Planet2.HpPlanet <= 0 && Planet3.HpPlanet <= 0)
        {
            Pause();
            WinLoseTab.SetActive(true);
            StatusGame.text = "You Win!!!";
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPause == true)
            {
                _isPause = false;
                Resume();
            }
            else
            {
                Pause();
                _isPause = true;
            }
        }
    }

    void Pause()
    {
        CameraMenu.SetActive(true);
        CameraGame.SetActive(false);
        StopAllCoroutines();
        Time.timeScale = 0f;
        _isPause = true;
    }

    public void Resume()
    {
        CameraMenu.SetActive(false);
        CameraGame.SetActive(true);
        WinLoseTab.SetActive(false);
        Time.timeScale = 1f;
        _isPause = false;
    }
}