using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isIdle = true;
    public bool isDead = false;
    [SerializeField] private int healthPoints = 100;

    private void Update()
    {
        if (healthPoints <= 0)
            isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (healthPoints > 0)
                healthPoints -= PlayerShoot.bulletDamage;

            Destroy(collision.gameObject);
        }
    }
}
