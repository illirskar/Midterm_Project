using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{

    public ParticleSystem winPrefab;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<GameManager>().OnPlayerFinish();
        Instantiate(winPrefab, other.transform);
    }
}
