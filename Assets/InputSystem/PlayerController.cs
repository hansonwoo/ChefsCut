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
    }

    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //movement = movement.normalized; // Prevents diagonal inputs from becoming artifically faster by about 40%

        //if (playerState == PlayerStates.Ready)
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        playerState = PlayerStates.DodgeRolling;
        //    }
        //}
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
    }

    public void DodgeRoll(InputAction.CallbackContext callbackContext)
    {
        Debug.Log($"DodgeRoll key pressed! {callbackContext.phase}");
        if (callbackContext.performed && playerState == PlayerStates.Ready)
        {
            var movementVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
            if (movementVector != Vector2.zero)
            {
                playerState = PlayerStates.DodgeRolling;
                dodgeRollVector2 = movementVector;
                dodgeRollStartTime = Time.time;
                dodgeRollDuration = dodgeRollDistance / dodgeRollSpeed;
            }
        }
    }
}
