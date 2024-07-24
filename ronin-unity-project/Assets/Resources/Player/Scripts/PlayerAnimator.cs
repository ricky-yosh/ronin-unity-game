using UnityEngine;

namespace RoninGame
{
    /// <summary>
    /// Centralized list of string constants to easily access Player Animation States
    /// </summary>
    public static class PlayerAnimationStates
    {
        public const string IS_RUNNING = "isRunning";
        public const string IS_ATTACKING = "isAttacking";
        public const string IS_DASHING = "isDashing";
    }

    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;

        private Animator animator;

        private void Update()
        {
            animator.SetBool(PlayerAnimationStates.IS_RUNNING, playerMovement.getIsRunning());
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            animator.SetBool(PlayerAnimationStates.IS_RUNNING, playerMovement.getIsRunning());
        }
    }
}