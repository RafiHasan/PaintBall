using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnGroundActions onGround;

    private PlayerMovement playerMovement;

    private PlayerLook look;
    

    [SerializeField] WeaponController weapon;
    private void Awake()
    {
        playerInput = new PlayerInput();
        onGround = playerInput.OnGround;
        //weaponActions = playerInput.Weapon;
        
        playerMovement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
    }

    private void FixedUpdate()
    {
        playerMovement.ProcessMove(onGround.Movement.ReadValue<Vector2>());

        onGround.Shoot.performed += _ => weapon.Shoot();
        

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
