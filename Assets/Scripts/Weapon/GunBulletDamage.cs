using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletDamage : MonoBehaviour
{
    [Header("Attributes")]
    public int bulletDamage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDamage);

        Destroy(gameObject);
    }
}
