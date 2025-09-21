using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    private Camera gameCamera;
    private Vector3 minCameraPoint;
    private Vector3 maxCameraPoint;
    private Vector3 bulletPosition;

    private void Start()
    {
        gameCamera = Camera.main;
    }

    private void Update()
    {
        bulletPosition = GetComponent<Transform>().position;

        minCameraPoint = gameCamera.ViewportToWorldPoint(new Vector3(0, 0)); //bottom left corner
        maxCameraPoint = gameCamera.ViewportToWorldPoint(new Vector3(1, 1)); //top right corner

        if (bulletPosition.x <= minCameraPoint.x)
        {
            Destroy(gameObject);
        }
        
    }
}
