using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public AudioSource bulletSound;

    private void Awake()
    {
        bulletSound.Play();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);// quaternion.identity means no rotation.
        Destroy(effect, 5f);
        Destroy(gameObject);

    }

}
