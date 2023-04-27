using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    private BallController bc;

    private bool canToggle = false;

    private void Start()
    {
        bc = FindAnyObjectByType<BallController>();
        menu.SetActive(false);

        RaceStarter rs = FindAnyObjectByType<RaceStarter>();
        rs.RegisterOnRaceStart(OnRaceStart);

        FindAnyObjectByType<FallDetector>().RegisterOnDeath(OnDeath);
    }

    private void OnRaceStart()
    {
        canToggle = true;
    }

    private void OnDeath()
    {
        canToggle = false;
    }

    private void Update()
    {
        if (canToggle == false) { return; }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            bc.EnableMovement();
            Timer.Instance.StartTimer();
        }
        else
        {
            menu.SetActive(true);
            bc.DisableMovement();
            Timer.Instance.StopTimer();
        }
    }

}