using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRadius = 20f;
    public float spawnInterval = 5f;
    public int maxEnemies = 10;

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
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        // Assign the player Transform to the new enemy instance
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.player = player;
        }

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