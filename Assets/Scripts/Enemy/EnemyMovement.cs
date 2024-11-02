using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private float baseSpeed;

    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy has reached the current waypoint
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            // If we've reached the end of the path, trigger home damage and destroy the enemy
            if (pathIndex == LevelManager.main.path.Length)
            {
                LevelManager.main.EnemyReachedHome(); // Inflict damage to the home
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            else
            {
                // Set the next waypoint as the target
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        // Move towards the target waypoint
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    // Method to update the enemy's speed dynamically
    public void Updatespeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    // Method to reset the enemy's speed to its base value
    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
