using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovementComponent : MonoBehaviour
{
    [SerializeField]
    MovementComponent movement;

    public void OnMoveInput(CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        movement.Move(moveDirection.normalized);
    }
}
