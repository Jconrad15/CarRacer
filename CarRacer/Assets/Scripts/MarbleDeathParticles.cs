using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleDeathParticles : MonoBehaviour
{
    private void Start()
    {
        GetComponent<ParticleSystem>().Stop();
        FindAnyObjectByType<FallDetector>().RegisterOnDeath(OnDeath);
    }

    private void OnDeath()
    {
        GetComponent<ParticleSystem>().Play();
    }


}
