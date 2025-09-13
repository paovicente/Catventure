using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private float playerSpeed = 50f;
    private Vector2 moveInput;

    private void Update()
    {
        if (!blackScreen.activeSelf) { //when the black start screen is disabled the player can move
            moveAction.action.started += HandleMoveInput;
            moveAction.action.performed += HandleMoveInput;
            moveAction.action.canceled += HandleMoveInput;

            movePlayer();
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
   
    private void movePlayer()
    {
        Vector3 move = new Vector3(moveInput.x, moveInput.y);

        transform.position += move * playerSpeed * Time.deltaTime;
    }
}
