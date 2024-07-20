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
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

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

            Vector3 mouseDirection = GetMouseDirection();
            if (mouseDirection != Vector3.zero)
            {
                foreach (var hitCollider in hitColliders)
                {
                    Vector3 directionToEnemy = (hitCollider.transform.position - transform.position).normalized;
                    float angleToEnemy = Vector3.Angle(mouseDirection, directionToEnemy);

                    if (angleToEnemy <= angle / 2)
                    {
                        EnemyHealth enemyHealth = hitCollider.GetComponent<EnemyHealth>();
                        if (enemyHealth != null)
                        {
                            enemyHealth.TakeDamage(damage);
                        }
                    }
                }
            }
        }

        private Vector3 GetMouseDirection()
        {
            if (mainCamera != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                Plane plane = new Plane(Vector3.up, player.position);

                if (plane.Raycast(ray, out float distance))
                {
                    Vector3 mousePosition = ray.GetPoint(distance);
                    Vector3 direction = (mousePosition - player.position).normalized;
                    direction.y = 0; // Keep the direction strictly horizontal
                    return direction;
                }
            }
            return Vector3.zero; // Return zero vector if direction can't be calculated
        }

        private void OnDrawGizmos()
        {
            if (mainCamera != null)
            {
                Vector3 mouseDirection = GetMouseDirection();
                Vector3 forward = transform.forward;
                Vector3 leftBoundary = Quaternion.Euler(0, -angle / 2, 0) * mouseDirection * radius;
                Vector3 rightBoundary = Quaternion.Euler(0, angle / 2, 0) * mouseDirection * radius;

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
                Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

                // Draw arc segments
                int segments = 5; // might limit efficiency if too high
                float angleStep = angle / segments;
                Vector3 previousPoint = transform.position + leftBoundary;

                for (int i = 1; i <= segments; i++)
                {
                    float currentAngle = -angle / 2 + i * angleStep;
                    Vector3 nextPoint = Quaternion.Euler(0, currentAngle, 0) * mouseDirection * radius + transform.position;
                    Gizmos.DrawLine(previousPoint, nextPoint);
                    previousPoint = nextPoint;
                }

                // Close the arc
                Gizmos.DrawLine(previousPoint, transform.position + rightBoundary);
            }
        }
    }
}
