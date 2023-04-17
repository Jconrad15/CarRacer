using UnityEngine;

/// <summary>
/// Singleton for tracking time
/// </summary>
public class Timer : MonoBehaviour
{
    private float currentTime = 0f;
    private bool isRunning = false;

    public static Timer Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            TickTimer();
        }
    }

    private void TickTimer()
    {
        currentTime += Time.deltaTime;
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public bool IsTimerRunning()
    {
        return isRunning;
    }

}
