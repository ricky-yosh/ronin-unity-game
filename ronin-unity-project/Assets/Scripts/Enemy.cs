using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;  // Reference to the player
    public float speed = 5f;  // Speed of the enemy

    void Update()
    {
        // Check the distance to the player
        float distance = Vector3.Distance(transform.position, player.position);
        
        // If the player is within a certain range, follow the player
        if (distance < 10f)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}