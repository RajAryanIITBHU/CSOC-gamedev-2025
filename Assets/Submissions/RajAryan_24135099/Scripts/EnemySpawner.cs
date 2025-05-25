using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberToSpawn = 5;
    public float spawnRadius = 0.5f;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public LayerMask collisionMask;

    public float retryDelay = 0.05f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    System.Collections.IEnumerator SpawnEnemies()
    {
        int spawned = 0;
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector2 center = (spawnAreaMin + spawnAreaMax) / 2f;
        Vector2 size = spawnAreaMax - spawnAreaMin;
        Gizmos.DrawWireCube(center, size);
    }
}
