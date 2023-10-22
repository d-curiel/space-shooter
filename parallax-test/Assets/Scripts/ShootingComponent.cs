using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class ShootingComponent : MonoBehaviour
{
    [SerializeField]
    Transform shootingPlace;
    public GameObject bulletPrefab;
    public ObjectPool bulletsObjectPool;

    void Start()
    {
        if (!shootingPlace)
        {
            shootingPlace = transform;
        }
        bulletsObjectPool = GetComponent<ObjectPool>();
        bulletsObjectPool.InitializePool(bulletPrefab);
    }

    public void Shoot()
    {
        GameObject nextBullet = bulletsObjectPool.GetItem();
        nextBullet.transform.position = shootingPlace.position;
        nextBullet.SetActive(true);
        nextBullet.TryGetComponent<MovementComponent>(out MovementComponent movement);
        if (movement)
        {
            movement.Move(gameObject.transform.up);
        }
    }
}
