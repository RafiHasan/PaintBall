using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Movement movement;

    PlayerInput playerInput;
    PlayerInput.GroundMovementActions groundMovement;

    [SerializeField]
    Vector2 horizontalInput;
    private void Awake()
    {
        playerInput = new PlayerInput();
        groundMovement = playerInput.GroundMovement;

        
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        //groundMovement.HorizontalMovement.canceled += ctx => horizontalInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        movement.RecieveInput(horizontalInput);
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
}

