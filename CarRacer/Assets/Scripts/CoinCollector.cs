using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private Action<int> cbOnPointsChanged;
    private Action<Coin> cbOnCoinCollected;

    private int totalPoints;
    private int TotalPoints
    {
        get => totalPoints;
        set
        {
            totalPoints = value;
            cbOnPointsChanged?.Invoke(totalPoints);
        }
    }

    private void Start()
    {
        TotalPoints = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin c))
        {
            int newPoints = c.Collect();
            TotalPoints += newPoints;
            cbOnCoinCollected?.Invoke(c);
        }
    }

    public void RegisterOnPointsChanged(Action<int> callbackfunc)
    {
        cbOnPointsChanged += callbackfunc;
    }

    public void UnregisterOnPointsChanged(Action<int> callbackfunc)
    {
        cbOnPointsChanged -= callbackfunc;
    }

    public void RegisterOnCoinCollected(Action<Coin> callbackfunc)
    {
        cbOnCoinCollected += callbackfunc;
    }

    public void UnregisterOnCoinCollected(Action<Coin> callbackfunc)
    {
        cbOnCoinCollected -= callbackfunc;
    }

}
