using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public GameObject collectablePrefab;
    public GameObject uncollectablePrefab;
    public float spawnDelay = 2f;
    public float spawnXRange = 8f;
    public float spawnY = 10f;
    public int maxItems = 5;

    [Range(0f, 1f)]
    public float collectableChance = 0.8f; // 80% chance to spawn collectable

    private List<GameObject> spawnedItems = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnItemsWithDelay());
    }

    IEnumerator SpawnItemsWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            // Clean up nulls from destroyed items
            spawnedItems.RemoveAll(item => item == null);

            if (spawnedItems.Count < maxItems)
            {
                float randomX = Random.Range(-spawnXRange, spawnXRange);
                Vector2 spawnPos = new Vector2(randomX, spawnY);

                GameObject prefabToSpawn = Random.value < collectableChance ? collectablePrefab : uncollectablePrefab;
                GameObject spawned = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);

                // Optional: slow down fall speed
                Rigidbody2D rb = spawned.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 0.5f;
                }

                spawnedItems.Add(spawned);
            }
        }
    }
}
