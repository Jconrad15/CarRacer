using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private Action cbOnReachGoal;

    public void OnPlayerCollideGoal()
    {
        Timer.Instance.StopTimer();
        cbOnReachGoal?.Invoke();
    }

    public void RegisterOnReachGoal(Action callbackfunc)
    {
        cbOnReachGoal += callbackfunc;
    }

    public void UnregisterOnReachGoal(Action callbackfunc)
    {
        cbOnReachGoal -= callbackfunc;
    }
}
