using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class RaceStarter : MonoBehaviour
{
    private Action cbOnRaceStart;

    [SerializeField]
    private TextMeshProUGUI countDownText;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip beepSound;
    [SerializeField]
    private AudioClip goSound;

    private void Start()
    {
        StartCoroutine(StartRace());
    }

    private IEnumerator StartRace()
    {
        yield return new WaitForSeconds(0.5f);
        countDownText.gameObject.SetActive(true);
        ShowText("3");
        PlaySound(false);

        yield return new WaitForSeconds(1);
        ShowText("2");
        PlaySound(false);

        yield return new WaitForSeconds(1);
        ShowText("1");
        PlaySound(false);

        yield return new WaitForSeconds(1);
        ShowText("GO");
        PlaySound(true);

        cbOnRaceStart?.Invoke();
        yield return new WaitForSeconds(1);
        Destroy(countDownText.gameObject);
    }

    private void ShowText(string text)
    {
        countDownText.SetText(text);
    }

    private void PlaySound(bool isGO)
    {
        if(isGO)
        {
            source.PlayOneShot(goSound);
        }
        else
        {
            source.PlayOneShot(beepSound);
        }
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
