using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    private Vector2 moveInput;
    private float jumpInput;
    [SerializeField] private float playerSpeed = 5f;
    private bool isJumping = false;

    [SerializeField] private GameObject blackScreen;
    
    private void Update()
    {
        if (!blackScreen.activeSelf) { //when the black start screen is disabled the player can move
            moveAction.action.started += HandleMoveInput;
            moveAction.action.performed += HandleMoveInput;
            moveAction.action.canceled += HandleMoveInput;
            MovePlayer();

            if (gameObject.transform.position.y < 0) /*if the cat is on the floor - only to test, it will be changed once 
                                                       * the tilemaps are correctly configured*/
            {
                isJumping = false;
            }

            if (isJumping == false){//to block a double jump
                jumpAction.action.started += HandleJumpInput;
                jumpAction.action.performed += HandleJumpInput;
                jumpAction.action.canceled += HandleJumpInput;
                Jump();
            }

            
            Debug.Log("black screen inactive");
        }
        else
        {
            Debug.Log(!blackScreen.activeSelf);
            Debug.Log("active in hierarchy: " + !blackScreen.activeInHierarchy);
        }
            
    }

    private void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void HandleJumpInput(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValue<float>();
    }

    private void MovePlayer()
    {
        Vector3 move = new Vector3(moveInput.x, moveInput.y);

        transform.position += move * playerSpeed * Time.deltaTime;
    }

    private void Jump()
    {
        isJumping = true;
        Debug.Log("Esta saltando");
    }
}
