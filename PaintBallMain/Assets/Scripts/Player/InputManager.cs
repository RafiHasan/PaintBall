using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnGroundActions onGround;

    private PlayerMovement playerMovement;

    private PlayerLook look;
    private void Awake()
    {
        playerInput = new PlayerInput();
        onGround = playerInput.OnGround;
        playerMovement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
    }

    private void FixedUpdate()
    {
        playerMovement.ProcessMove(onGround.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onGround.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onGround.Enable();
    }

    private void OnDisable()
    {
        onGround.Disable();
    }
}
