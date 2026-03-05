using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Chasing settings")]
    public float enemySpeed = 5f;
    public Transform target;
    public float rotationSpeed = 0.0025f;
    public float bulletForce = 20f;

    [Header("References")]
    private Rigidbody2D rb;

    [Header("Distance for the enemy to shoot")]
    public float distanceToShoot = 5f;
    public float distanceToStop = 2f;

    [Header("Firing rate for the enemy")]
    public float fireRate = 1;
    public float timer = 0;

    [Header("References for bullet and firepoint")]
    public Transform firePoint;
    public ObjectPooler pooler;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = fireRate;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pooler = FindObjectOfType<ObjectPooler>();
    }

    private void Update()
    {
        if (target != null)
        {
            RotateTowardsTarget();
        }

        if (Vector2.Distance(transform.position, target.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (timer < Time.time)
        {
            GameObject bullet = pooler.SpawnFromPools("EnemyBullet", firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
            timer = fireRate + Time.time;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) >= distanceToShoot)
        {
            rb.linearVelocity = transform.up * enemySpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void RotateTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);
    }
}
