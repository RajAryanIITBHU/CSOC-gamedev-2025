using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberToSpawn = 5;
    public float spawnRadius = 0.5f;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public LayerMask collisionMask;
    private int spawned = 0;
    

    public float retryDelay = 0.05f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    System.Collections.IEnumerator SpawnEnemies()
    {
        while (spawned < numberToSpawn)
        {
            Vector2 spawnPos = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            if (!Physics2D.OverlapCircle(spawnPos, spawnRadius, collisionMask))
            {
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                spawned++;
            }
            else
            {
                yield return new WaitForSeconds(retryDelay);
            }
        }
    }
}
