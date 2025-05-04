using UnityEngine;
using System.Collections;

public class ItemSpawner : MonoBehaviour
{
    public GameObject collectablePrefab;
    public GameObject uncollectablePrefab;
    public float spawnDelay = 2f;
    public float spawnXRange = 8f;
    public float spawnY = 10f;

    [Range(0f, 1f)]
    public float collectableChance = 0.8f; // 80% chance to spawn collectable

    void Start()
    {
        StartCoroutine(SpawnItemsWithDelay());
    }

    IEnumerator SpawnItemsWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            float randomX = Random.Range(-spawnXRange, spawnXRange);
            Vector2 spawnPos = new Vector2(randomX, spawnY);

            // Use weighted random
            GameObject itemToSpawn = Random.value < collectableChance ? collectablePrefab : uncollectablePrefab;

            Instantiate(itemToSpawn, spawnPos, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log($"{gameObject.tag} touched the ground and was destroyed.");
            Destroy(gameObject);
        }
    }

}

