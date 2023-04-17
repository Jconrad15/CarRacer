using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public void OnPlayerCollideGoal()
    {
        Debug.Log("Player reached the goal");
        Timer.Instance.StopTimer();
    }
}
