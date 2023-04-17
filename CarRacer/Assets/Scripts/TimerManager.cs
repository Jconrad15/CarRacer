using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    private void Start()
    {
        RaceStarter rs = FindAnyObjectByType<RaceStarter>();
        rs.RegisterOnRaceStart(OnRaceStart);
    }

    private void OnRaceStart()
    {
        Timer.Instance.ResetTimer();
        Timer.Instance.StartTimer();
    }
}
