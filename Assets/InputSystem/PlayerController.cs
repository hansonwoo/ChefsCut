using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float movementSpeed;

    [SerializeField]
    public float dodgeRollSpeed;

    [SerializeField]
    public float dodgeRollDistance;

    [SerializeField]
    public int dodgeChargeMax;

    [SerializeField]
    public float dodgeRechargeDuration;

    private int dodgeCharge;

    private float dodgeRechargeStartTime;

    private Vector2 dodgeRollVector2;

    private float dodgeRollDuration;

    private float dodgeRollStartTime;

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    public Vector2 movement;

    private PlayerStates playerState;
    private PlayerInputActions playerInputActions;

    private enum PlayerStates
    {
        Ready,
        DodgeRolling,
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.DodgeRoll.performed += DodgeRoll;

        dodgeCharge = dodgeChargeMax;
    }

    private void FixedUpdate()
    {
        Vector2 movementVector = playerInputActions.Player.Movement.ReadValue<Vector2>();

        if (playerState == PlayerStates.DodgeRolling && Time.time >= dodgeRollStartTime + dodgeRollDuration)
            playerState = PlayerStates.Ready;

        switch (playerState)
        {
            case PlayerStates.Ready:
                playerRigidbody.MovePosition(playerRigidbody.position + movementVector * movementSpeed * Time.fixedDeltaTime);
                break;
            case PlayerStates.DodgeRolling:
                playerRigidbody.MovePosition(playerRigidbody.position + dodgeRollVector2 * dodgeRollSpeed * Time.fixedDeltaTime);
                break;
        }

        if (dodgeCharge < dodgeChargeMax)
        {
            if (Time.time >= dodgeRechargeStartTime + dodgeRechargeDuration)
            {
                dodgeCharge++;
            }
        }
    }

    public void DodgeRoll(InputAction.CallbackContext callbackContext)
    {
        if (dodgeCharge > 0)
        {
            if (callbackContext.performed && playerState == PlayerStates.Ready)
            {
                var movementVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
                if (movementVector != Vector2.zero) // TODO: Roll in the direction you're looking if there is no movement input
                {
                    playerState = PlayerStates.DodgeRolling;
                    dodgeRollVector2 = movementVector;
                    dodgeRollStartTime = Time.time;
                    dodgeRollDuration = dodgeRollDistance / dodgeRollSpeed;
                    dodgeRechargeStartTime = Time.time;
                    dodgeCharge--;
                }
            }
        }
    }
}
