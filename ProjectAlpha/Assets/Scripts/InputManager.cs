using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.MovementActions movement;

    private PlayerMovement motor;
    private Aim aim; 

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        movement = playerInput.Movement;
        motor = GetComponent<PlayerMovement>();
        aim = GetComponent<Aim>();

        movement.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        motor.ProcessMove(movement.Moving.ReadValue<Vector2>());        
    }

    private void LateUpdate()
    {
        aim.ProcessLook(movement.Aim.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }
}
