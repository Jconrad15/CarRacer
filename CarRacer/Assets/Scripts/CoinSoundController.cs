using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip soundClip;
    private AudioSource audioSource;
    private Coin coin;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        coin = GetComponentInParent<Coin>();

        FindAnyObjectByType<CoinCollector>()
            .RegisterOnCoinCollected(OnCoinCollected);
    }

    private void OnCoinCollected(Coin c)
    {
        if (coin != c) { return; }

        audioSource.PlayOneShot(soundClip);
    }

}
