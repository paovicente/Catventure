using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private GameObject blackScreen;

    [Header("Inputs")]
    private Vector2 moveInput;

    [Header("Player variables")]
    [SerializeField] private float playerSpeed = 2f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Rigidbody2D playerRigidbody;
    public bool colFeet = false;
    private BoxCollider2D playerCollider;

    [Header("Player states")]
    public bool isRunning = false;
    public bool isJumping = false;
    public bool isIdle = false;

    private void Start()
    {
        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;

        jumpAction.action.started += HandleJumpInput;
        jumpAction.action.performed += HandleJumpInput;
        jumpAction.action.canceled += HandleJumpInput;

        playerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!blackScreen.activeSelf) //when the black start screen is disabled the player can move
        {
            MovePlayer();

            colFeet = CheckFloor.colFeet;
            isJumping = !colFeet; //if the cat is jumping then he doesnt have the feet on a floor or a platform
        }
    }

    private void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandleJumpInput(InputAction.CallbackContext context) //the cat will jump only if the player use the space bar and the catfeet are touching a platform or the floor
    {
        if (!blackScreen.activeSelf && colFeet)
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, jumpForce);
            isJumping = true;
            
            isIdle = false;
            isRunning = false;
        }
        
    }

    private void MovePlayer()
    {
        //Vector3 move = new Vector3(moveInput.x, 0); //the jump (move in y) will be managed separatedly
        //transform.position += move * playerSpeed * Time.deltaTime;

        playerRigidbody.linearVelocity = new Vector2(moveInput.x * playerSpeed, playerRigidbody.linearVelocity.y); //the cat moves in x according to the input and maintains velocity in y 

        if (isJumping)//if the cat isJumping then the cat is not running or idle
        {
            isRunning = false;
            isIdle = false;
        }else 
            if (moveInput.x != 0) //if the cat is not jumping means that the cat is on a platform or floor, and he moves then is running
            {
                isRunning = true;
                isIdle = false;
            }
            else //if the cat is not jumping means that the cat is on a platform or floor, and he dont move then is idle
            {
                isRunning = false;
                isIdle = true;
            }
    }

}
