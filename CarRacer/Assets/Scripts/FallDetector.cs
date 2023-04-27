using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
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
            FindAnyObjectByType<EscapeMenu>().TurnOffAbilityToToggle();
            Timer.Instance.StopTimer();
            FindAnyObjectByType<BallController>().DisableMovement();
            deathMenu.SetActive(true);
        }
    }

}
