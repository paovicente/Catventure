using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private string isRunningParameter = "isRunning";
    [SerializeField] private string isIdleParameter = "isIdle";
    [SerializeField] private string isJumpingParameter = "isJumping";

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject blackScreen;
    private PlayerController playerScript;

    private int isRunningHash;
    private int isIdleHash;
    private int isJumpingHash;

    private void Start()
    {
        playerScript = GetComponent<PlayerController>();

        isRunningHash = Animator.StringToHash(isRunningParameter);
        isIdleHash = Animator.StringToHash(isIdleParameter);
        isJumpingHash = Animator.StringToHash(isJumpingParameter);
    }

    private void Update()
    {
        if (blackScreen.activeSelf)
        {
            animator.enabled = false; 
        }
        else
        {
            animator.enabled = true;
            animator.SetBool(isRunningHash, playerScript.isRunning);
            animator.SetBool(isJumpingHash, playerScript.isJumping);
            animator.SetBool(isIdleHash, playerScript.isIdle);
        }
            
    }
}
