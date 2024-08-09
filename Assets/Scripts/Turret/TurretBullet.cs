using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private Transform target;
    private Vector2 startPosition;
    private Turret turret; // Reference to the turret

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    public AudioSource turretBulletSound;

    private void Awake()
    {
        turretBulletSound.Play();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * bulletSpeed;
        }

        // Check if the bullet has traveled beyond the turret's range
        float distanceTraveled = Vector2.Distance(startPosition, transform.position);
        if (distanceTraveled >= turret.targettingRange)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform _target, Turret _turret)
    {
        target = _target;
        turret = _turret; // Assign the turret reference
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the collided object is an enemy
        if (other.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
        {
            enemyHealth.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        // Ignore collisions with other bullets
        else if (other.gameObject.layer == LayerMask.NameToLayer("TurretBullet"))
        {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }
    }
}
