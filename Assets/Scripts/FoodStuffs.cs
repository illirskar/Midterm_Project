using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodStuffs : MonoBehaviour
{
    [Range(1, 5)]
    public int HP;

    public Material Gradient;
    public TMP_Text HP_Count;

    public ParticleSystem foodPrefab;

    public BodyMechanics BodyCreator;

    private string _HPCount;
    void Start()
    {
        GetComponent<Renderer>().material = Gradient;

        float rand = Random.value;
        if (rand >= .9f) { HP = 5; }
        else { HP = Random.Range(1, 4); };
        _HPCount = HP.ToString();

        GetComponent<Renderer>().material.SetFloat("HP_Req", HP);

        HP_Count.SetText(_HPCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        AddParts(HP);
        Transform particlePos = other.GetComponent<Rigidbody>().transform;
        Instantiate(foodPrefab, particlePos);
        Destroy(gameObject);
    }

    public void AddParts(int amountToAdd)
    {
        BodyCreator.AddParts(amountToAdd);
    }
}
