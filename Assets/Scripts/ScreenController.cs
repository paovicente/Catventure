using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private InputActionReference startAction;
    
    private void OnEnable()
    {
        startAction.action.performed += HandleStartGame;
        Debug.Log("Key S Pressed");
    }

    private void HandleStartGame(InputAction.CallbackContext context)
    {
        gameObject.SetActive(false); //the start screen will disappear
    }
 
}
