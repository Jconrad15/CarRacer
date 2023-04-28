using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private readonly float parTime = 60;

    public int DetermineScore()
    {
        int points = FindAnyObjectByType<CoinCollector>().TotalPoints;
        float time = Timer.Instance.GetCurrentTime();
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        float seconds = (float)timeSpan.TotalSeconds;

        int difference = Mathf.RoundToInt(parTime - seconds);
        int score = difference + points;

        return score;
    }




}
