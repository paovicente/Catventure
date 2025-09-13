using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private InputActionReference startAction;
    
    private void Start()
    {
        startAction.action.performed += HandleStartGame;
    }

    private void HandleStartGame(InputAction.CallbackContext context)
    {
        gameObject.SetActive(false); //the start screen will disappear
    }
 
}
