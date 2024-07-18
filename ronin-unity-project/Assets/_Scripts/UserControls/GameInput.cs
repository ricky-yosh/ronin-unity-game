using UnityEngine;

namespace RoninGame
{
    public class GameInput : MonoBehaviour
    {
        private PlayerInputActions playerInputActions;

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.Player.Enable();
        }

        public Vector2 GetMovementVectorNormalized()
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

            inputVector = inputVector.normalized;

            return inputVector;
        }

        public bool GetDashInput()
        {
            return playerInputActions.Player.Dash.triggered;
        }
    }
}