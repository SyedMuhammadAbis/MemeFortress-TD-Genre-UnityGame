using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip shootClip;
    private AudioSource audioSource;
    public LayerMask turretLayer;

    private UIRaycaster uiRaycaster;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        uiRaycaster = gameObject.AddComponent<UIRaycaster>();
    }

    public void PlayShootSound()
    {
        if (shootClip != null)
        {
            audioSource.PlayOneShot(shootClip);
        }
        else
        {
            Debug.LogWarning("Shoot clip not set in SoundManager.");
        }
    }

    public bool IsPointerOverTurretPlacementBlock()
    {
        Vector2 rayPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, Mathf.Infinity, turretLayer);

        if (hit.collider != null)
        {
            Debug.Log("Cursor is over: " + hit.collider.name);
            // Check if the hit object is a turret placement block
            return hit.collider.CompareTag("TurretPlacementBlock");
        }

        Debug.Log("Cursor is not over any turret placement block");
        return false;
    }

    public bool IsPointerOverUI()
    {
        return uiRaycaster.IsPointerOverUIElement();
    }
}
