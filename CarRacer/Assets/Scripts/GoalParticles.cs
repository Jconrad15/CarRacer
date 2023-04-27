using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalParticles : MonoBehaviour
{
    private void Start()
    {
        GetComponent<ParticleSystem>().Stop();
        FindAnyObjectByType<Goal>().RegisterOnReachGoal(OnReachGoal);
    }

    private void OnReachGoal()
    {
        GetComponent<ParticleSystem>().Play();
    }
}
