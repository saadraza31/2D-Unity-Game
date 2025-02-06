using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject TrashItem;
    public float spawnRate = 3f;
    private float timer = 0f;
    private bool isSpawningActive = true;

    private void Update()
    {
        if (!isSpawningActive) return; // Stop spawning if not active

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnItem();
            timer = 0f;
        }
    }

    void spawnItem()
    {
        if (!isSpawningActive) return; // Ensure no spawning when inactive
        Instantiate(TrashItem, transform.position, transform.rotation);
    }

    public void StopSpawning()
    {
        isSpawningActive = false; // Disable spawning
    }
}
