using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to be spawned
    public Transform player;  // Reference to the player
    public float spawnRadius = 20f;  // Radius around the player where enemies can spawn
    public float spawnInterval = 5f;  // Time interval between spawns
    public int maxEnemies = 10;  // Maximum number of enemies allowed to be active

    private float nextSpawnTime;
    private int currentEnemyCount;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        currentEnemyCount = 0;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomPositionAroundPlayer();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemyCount++;
    }

    Vector3 GetRandomPositionAroundPlayer()
    {
        float angle = Random.Range(0f, 360f);
        float distance = Random.Range(0f, spawnRadius);
        Vector3 spawnDirection = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * distance;
        return player.position + spawnDirection;
    }

    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
