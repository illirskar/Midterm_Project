using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CubeBlock : MonoBehaviour
{
    [Range(0,50)]
    public int HP;

    public Material Gradient;
    public TMP_Text HP_Count;

    public ParticleSystem breakPrefab;

    public BodyMechanics BodyCreator;

    private string _HPCount;
    private void Start()
    {
        GetComponent<Renderer>().material = Gradient;

        float rand = Random.value;
        if (rand <= 0.2f) { HP = Random.Range(1, 5); } 
        else if (rand <= 0.4f) { HP = Random.Range(6, 15); } 
        else if (rand <= 0.6f) { HP = Random.Range(16, 25); } 
        else if (rand <= 0.8f ) { HP = Random.Range(26, 35); } 
        else if (rand <= 0.95f) { HP = Random.Range(36, 50); };

        _HPCount = HP.ToString();
        HP_Count.SetText(_HPCount);

        GetComponent<Renderer>().material.SetFloat("HP_Req", HP);
        
    }

    private void OnTriggerStay(Collider other)
    {
        HP -= 1;
        _HPCount = HP.ToString();
        Gradient.SetFloat("HP_Req", HP);
        HP_Count.SetText(_HPCount);

        RemoveParts(1);

        if (HP <= 0) 
        {
            Transform particlePos = other.GetComponent<Rigidbody>().transform;
            Instantiate(breakPrefab, particlePos);
            Destroy(gameObject); 
        };
    }

    public void RemoveParts(int amountToRemove)
    {
        BodyCreator.RemoveParts(amountToRemove);
    }
}
