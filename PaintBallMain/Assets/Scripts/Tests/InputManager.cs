using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    Movement movement;

    Vector2 mouseInput;

    [SerializeField]
    MouseLookTest mouseLook;

    PlayerInput playerInput;
    PlayerInput.GroundMovementActions groundMovement;

    [SerializeField]
    Vector2 horizontalInput;
    private void Awake()
    {
        playerInput = new PlayerInput();
        groundMovement = playerInput.GroundMovement;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();

    }

    private void Update()
    {
        movement.RecieveInput(horizontalInput);
        mouseLook.RecieveInput(mouseInput);
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

