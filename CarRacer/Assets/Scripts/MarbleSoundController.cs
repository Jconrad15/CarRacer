using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleSoundController : MonoBehaviour
{
    private AudioSource audioSource;
    private Rigidbody rb;
    private BallController ballController;

    private float upperSpeedThreshold = 7f;
    private float lowerSpeedThreshold = 0.1f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponentInParent<Rigidbody>();
        ballController = GetComponentInParent<BallController>();
        SetVolume();
    }

    private void Update()
    {
        SetVolume();
    }

    private void SetVolume()
    {
        float speed = rb.velocity.magnitude;
        float volume;

        if (ballController.IsGrounded() == false)
        {
            volume = 0f;
        }
        else if (speed >= upperSpeedThreshold)
        {
            volume = 1;
        }
        else if (speed <= lowerSpeedThreshold)
        {
            volume = 0;
        }
        else
        {
            volume = speed / upperSpeedThreshold;
        }

        audioSource.volume = volume;

    }


}
