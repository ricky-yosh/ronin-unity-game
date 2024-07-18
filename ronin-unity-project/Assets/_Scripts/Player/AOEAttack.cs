using UnityEngine;

namespace RoninGame
{
    public class AOEAttack : MonoBehaviour
    {
        public float radius = 5f;
        public float angle = 90f;
        public int damage = 25;
        public LayerMask enemyLayer;
        public Transform player;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PerformAOEAttack();
            }
        }

        private void PerformAOEAttack()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
            
            foreach (var hitCollider in hitColliders)
            {
                EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
