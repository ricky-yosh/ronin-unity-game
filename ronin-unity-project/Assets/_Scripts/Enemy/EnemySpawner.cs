using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public Transform playerCamera;
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
        EnemyMovement enemyScript = newEnemy.GetComponent<EnemyMovement>();
        EnemyHealthBarCanvas billboard = newEnemy.GetComponentInChildren<EnemyHealthBarCanvas>();
        if (enemyScript != null && billboard != null)
        {
            enemyScript.player = player;
            billboard.SetCamera(playerCamera);
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

    // Draw gizmos to visualize the spawn radius and spawn points
    void OnDrawGizmos()
    {
        // Draw the spawn radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, spawnRadius);

        // Draw a gizmo for the next potential spawn point
        Gizmos.color = Color.green;
        Vector3 spawnPosition = GetRandomPositionAroundPlayer();
        Gizmos.DrawSphere(spawnPosition, 1f);
    }
}