using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerUI : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI timeText;

    private void Update()
    {
        float totalSeconds = Timer.Instance.GetCurrentTime();
        TimeSpan timeSpan = TimeSpan.FromSeconds(totalSeconds);
        string time = timeSpan.ToString("mm':'ss':'fff");
        timeText.SetText(time);
    }
}
