using System;
using System.Collections;
using UnityEngine;

public class RaceStarter : MonoBehaviour
{
    private Action cbOnRaceStart;

    private void Start()
    {
        StartCoroutine(StartRace());
    }

    private IEnumerator StartRace()
    {
        yield return new WaitForSeconds(3);



        cbOnRaceStart?.Invoke();
    }

    public void RegisterOnRaceStart(Action callbackfunc)
    {
        cbOnRaceStart += callbackfunc;
    }

    public void UnregisterOnRaceStart(Action callbackfunc)
    {
        cbOnRaceStart -= callbackfunc;
    }
}
