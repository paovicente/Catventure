using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private string isDeadParameter = "isDead";
    [SerializeField] private string isIdleParameter = "isIdle";
    [SerializeField] private string isAttackingParameter = "isAttacking";

    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject blackScreen;
    private EnemyController enemyScript;

    private int isDeadHash;
    private int isIdleHash;
    private int isAttackingHash;

    private void Start()
    {
        enemyScript = GetComponent<EnemyController>();

        isDeadHash = Animator.StringToHash(isDeadParameter);
        isIdleHash = Animator.StringToHash(isIdleParameter);
        isAttackingHash = Animator.StringToHash(isAttackingParameter);
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
            animator.SetBool(isDeadHash, enemyScript.isDead);
            animator.SetBool(isIdleHash, enemyScript.isIdle);
            animator.SetBool(isAttackingHash, enemyScript.isAttacking);
        }
    }
}

