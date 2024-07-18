using UnityEngine;

namespace RoninGame
{
    public class AOEIndicator : MonoBehaviour
    {
        public float radius = 5f;
        public float angle = 90f;
        public Color color = new Color(1f, 0.5f, 0f, 0.5f); // Semi-transparent orange
        public Transform player; // Reference to the player's transform
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (player != null)
            {
                transform.position = player.position;
                AimAtMouse();
            }
        }

        private void AimAtMouse()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, player.position);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 mousePosition = ray.GetPoint(distance);
                Vector3 direction = mousePosition - player.position;
                direction.y = 0; // Keep the direction strictly horizontal
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            DrawArc(transform.position, radius, angle);
        }

        private void DrawArc(Vector3 center, float radius, float angle)
        {
            int segments = 100;
            float angleStep = angle / segments;
            Vector3[] points = new Vector3[segments + 1];

            for (int i = 0; i <= segments; i++)
            {
                float currentAngle = (i * angleStep - angle / 2) * Mathf.Deg2Rad;
                points[i] = new Vector3(Mathf.Sin(currentAngle) * radius, 0, Mathf.Cos(currentAngle) * radius) + center;
            }

            for (int i = 0; i < segments; i++)
            {
                Gizmos.DrawLine(points[i], points[i + 1]);
            }
        }
    }
}
