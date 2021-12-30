using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BodyMechanics : MonoBehaviour
{
    public GameObject snakePartPrefab;

    public float spawningOffset = -0.85f;
    public float spawnDespawnDelay = 0.1f;
    public int totalActiveParts;

    public TMP_Text Text;

    public GameManager Manager;
    [SerializeField] private List<GameObject> parts = new List<GameObject>();

    private Vector3 _currentSpawnPos;

    private float _currentOffset;

    public void AddParts(int amountToAdd)
    {
        StartCoroutine(AddPartsOverTime(amountToAdd));
    }

    public void RemoveParts(int amountToRemove)
    {
        StartCoroutine(RemovePartsOverTime(amountToRemove));
    }

    private IEnumerator AddPartsOverTime(int toAdd)
    {
        for (int i = 0; i < toAdd; i++) // Spawn parts based on food eaten
        {
            _currentSpawnPos = transform.position;
            Vector3 spawnPos;
            if (parts.Count > 0)
            {
                spawnPos = parts[parts.Count - 1].transform.position;
                spawnPos.z += spawningOffset;
            }
            else
            {
                _currentOffset += spawningOffset;
                _currentSpawnPos.z += _currentOffset;
                spawnPos = _currentSpawnPos;
            }

            GameObject newPart = Instantiate(snakePartPrefab, spawnPos, Quaternion.identity, transform); // Will try to add hinge joint later
            parts.Add(newPart);
            yield return new WaitForSeconds(spawnDespawnDelay);
        }

        totalActiveParts = parts.Count; // Update active parts 
        Text.SetText(totalActiveParts.ToString());

        yield return null;
    }

    private IEnumerator RemovePartsOverTime(int toRemove)
    {
        int partsAmount = parts.Count;
        if (partsAmount < toRemove)
        {
            // Death loop
            foreach (var part in parts) // Destroy all body parts
            {
                Destroy(part);
                yield return new WaitForSeconds(spawnDespawnDelay);
            }
            parts.Clear();
            Manager.OnPlayerDeath();
            _currentOffset = 0f;
            yield break;
        }

        for (int i = 0; i < toRemove; i++) // Removes parts
        {
            Destroy(parts[parts.Count - 1]);
            parts.RemoveAt(parts.Count - 1);
            _currentOffset -= spawningOffset;
            yield return new WaitForSeconds(spawnDespawnDelay);
        }

        totalActiveParts = parts.Count;
        Text.SetText(totalActiveParts.ToString());

        yield return null;
    }
}