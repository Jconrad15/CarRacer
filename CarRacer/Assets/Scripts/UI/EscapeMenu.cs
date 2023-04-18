using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    private BallController bc;

    private void Start()
    {
        bc = FindAnyObjectByType<BallController>();
        menu.SetActive(false);
    }

    private void Update()
    {
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