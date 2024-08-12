using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float fireRate = 0.2f; // Time in seconds between each shot

    private bool isShooting = false;
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            isShooting = true;
            StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (isShooting)
        {
            // Check if the cursor is not over the turret placement block or UI element
            if (!soundManager.IsPointerOverTurretPlacementBlock() && !soundManager.IsPointerOverUI())
            {
                Shoot();
                soundManager.PlayShootSound();
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
