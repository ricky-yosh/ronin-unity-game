using UnityEngine;

namespace RoninGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 7f;
        [SerializeField] private float dashSpeed = 20f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldown = 1f;
        [SerializeField] private GameInput gameInput;

        private Rigidbody playerRigidbody;

        // Movement
        private bool isRunning;
        private bool isDashing = false; 

        // Dashing Extra
        private float dashTimeLeft;
        private float dashCooldownTimer;
        private Vector3 dashDirection;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleDash();
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (isDashing) return; // Skip regular movement while dashing

            Vector2 inputVector = gameInput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            playerRigidbody.MovePosition(playerRigidbody.position + moveDir * moveSpeed * Time.deltaTime);

            float rotateSpeed = 10f;
            if (moveDir != Vector3.zero)
            {
                playerRigidbody.MoveRotation(Quaternion.Slerp(playerRigidbody.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * rotateSpeed));
            }

            // Set boolean value for running
            isRunning = moveDir != Vector3.zero;
        }

        private void HandleDash()
        {
            if (isDashing)
            {
                dashTimeLeft -= Time.deltaTime;
                playerRigidbody.MovePosition(playerRigidbody.position + dashDirection * dashSpeed * Time.deltaTime);
                if (dashTimeLeft <= 0)
                {
                    isDashing = false;
                    dashCooldownTimer = dashCooldown;
                }
            }
            else
            {
                if (dashCooldownTimer > 0)
                {
                    dashCooldownTimer -= Time.deltaTime;
                }

                if (gameInput.GetDashInput() && dashCooldownTimer <= 0)
                {
                    StartDash();
                }
            }
        }

        private void StartDash()
        {
            isDashing = true;
            dashTimeLeft = dashDuration;
            Vector2 inputVector = gameInput.GetMovementVectorNormalized();
            dashDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        }

        /// <summary>
        /// Getter for if player is running which means WASD movement
        /// </summary>
        /// <returns> Boolean Value if Player is Running </returns>
        public bool getIsRunning()
        {
            return isRunning;
        }

        /// <summary>
        /// Getter for if player is dashing
        /// </summary>
        /// <returns> Boolean Value if Player is Dashing </returns>
        public bool getIsDashing()
        {
            return isDashing;
        }

    } // class
} // namespace