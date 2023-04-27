using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pointsText;

    private void Start()
    {
        FindAnyObjectByType<CoinCollector>()
            .RegisterOnPointsChanged(OnPointsChanged);
    }

    private void OnPointsChanged(int points)
    {
        pointsText.SetText(points.ToString());
    }

}
