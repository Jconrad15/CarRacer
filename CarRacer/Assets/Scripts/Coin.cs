using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int points;

    public int Collect()
    {
        StartCoroutine(CleanUp());
        return points;
    }

    private IEnumerator CleanUp()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
