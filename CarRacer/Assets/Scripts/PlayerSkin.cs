using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    [SerializeField]
    private Material[] skins;

    private void Start()
    {
        GetComponent<MeshRenderer>().material =
            skins[Random.Range(0, skins.Length)];
    }
}
