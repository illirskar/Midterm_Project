using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleWSound : MonoBehaviour
{

    public AudioSource Sound;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(this, Sound.clip.length);
    }
}