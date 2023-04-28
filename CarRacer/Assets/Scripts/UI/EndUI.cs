using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;

    [SerializeField]
    private TextMeshProUGUI pointsText;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private GameObject menu;

    private void Start()
    {
        FindAnyObjectByType<Goal>().RegisterOnReachGoal(OnReachGoal);
        menu.SetActive(false);
    }

    private void OnReachGoal()
    {
        SetTimeText();
        SetPointsText();
        SetScoreText();
        menu.SetActive(true);
    }

    private void SetTimeText()
    {
        float totalSeconds = Timer.Instance.GetCurrentTime();
        TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
        string time = timeSpan.ToString("mm':'ss':'fff");
        timeText.SetText(time);
    }

    private void SetPointsText()
    {
        int points = FindAnyObjectByType<CoinCollector>().TotalPoints;

        pointsText.SetText(points.ToString());
    }

    private void SetScoreText()
    {
        int score = FindAnyObjectByType<ScoreManager>().DetermineScore();
        scoreText.SetText(score.ToString());
    }

}
