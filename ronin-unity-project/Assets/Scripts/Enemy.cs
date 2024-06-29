using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public Transform player;  // This will be assigned at runtime
    public float speed = 5f;
    public float attackRange = 2f;
    public int attackDamage = 10;

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < attackRange)
            {
                // AttackPlayer();
            }
            else if (distance < 10f)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }

    // void AttackPlayer()
    // {
    //     PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
    //     if (playerHealth != null)
    //     {
    //         playerHealth.TakeDamage(attackDamage);
    //     }
    // }

    void OnDestroy()
    {
        // Notify the spawner if needed
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
        {
            spawner.EnemyDestroyed();
        }
    }
}
