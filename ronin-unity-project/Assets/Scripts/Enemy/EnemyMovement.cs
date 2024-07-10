using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
}
