using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isIdle = true;
    public bool isDead = false;
    public bool isAttacking = false;
    [SerializeField] private int healthPoints = 100;
    private float timeToIdle = 2f;
    private float attackTimer = 0f;

    private void Update()
    {
        if (healthPoints <= 0)
        {
            isDead = true;
        }
        else if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f) //the enemy returns to idle state
            {
                isAttacking = false;
                isIdle = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (healthPoints > 0)
                healthPoints -= PlayerShoot.bulletDamage;

            isAttacking = true;
            isIdle = false;

            attackTimer = timeToIdle;

            Destroy(collision.gameObject);
        }
    }
}
