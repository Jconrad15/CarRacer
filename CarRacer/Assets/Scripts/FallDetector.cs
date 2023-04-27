using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    private Action cbOnDeath;

    [SerializeField]
    private GameObject deathMenu;

    private void Start()
    {
        deathMenu.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            // open death menu
            cbOnDeath?.Invoke();
            Timer.Instance.StopTimer();
            deathMenu.SetActive(true);
        }
    }

    public void RegisterOnDeath(Action callbackfunc)
    {
        cbOnDeath += callbackfunc;
    }

    public void UnregisterOnDeath(Action callbackfunc)
    {
        cbOnDeath -= callbackfunc;
    }

}
