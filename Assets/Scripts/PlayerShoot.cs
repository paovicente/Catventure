using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private float offset = 1f;

    [Header("References")]
    [SerializeField] private GameObject bulletPrefab;  
    [SerializeField] private Transform firePoint;
    [SerializeField] private InputActionReference shootAction;
    [SerializeField] private GameObject blackScreen;

    [Header("Bullet settings")]
    [SerializeField] private float bulletSpeed = 1f;
    public static int bulletDamage = 10;

    private void Start()
    {
        shootAction.action.started += HandleShootInput;
        shootAction.action.canceled -= HandleShootInput;
    }

    private void HandleShootInput(InputAction.CallbackContext context)
    {
        if (!blackScreen.activeSelf) 
            Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(firePoint.parent.position.x - offset, firePoint.parent.position.y), firePoint.parent.rotation, firePoint);

        bullet.tag = "Bullet";

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        bulletRigidbody.linearVelocity = Vector2.left * bulletSpeed;

    }
}
