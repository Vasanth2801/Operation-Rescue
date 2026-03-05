using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private float bulletForce = 20f;

    [Header("References")]
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private Transform firePoint;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = pooler.SpawnFromPools("Bullet", firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce,ForceMode2D.Impulse);
    }
}