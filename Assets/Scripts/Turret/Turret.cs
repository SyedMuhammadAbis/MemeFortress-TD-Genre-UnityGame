using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject upgradeUi;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private TextMeshProUGUI errorMessageText;
    [SerializeField] private int upgradeCost = 100;
    [SerializeField] private LineRenderer lineRenderer; // LineRenderer for the 2D range indicator

    [Header("Attributes")]
    [SerializeField] public float targettingRange = 5f;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float bulletPerSecond = 1f;

    private Transform target;
    private float timeUntilFire;
    private int level = 1;

    void Start()
    {
        upgradeButton.onClick.AddListener(UpgradeTurret);
        UpdateUpgradeCostText();

        // Initialize the LineRenderer for the range indicator
        lineRenderer.positionCount = 0; // Hide initially
        DrawRangeIndicator(targettingRange);
    }

    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bulletPerSecond)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject bulletobj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        TurretBullet turretBulletScript = bulletobj.GetComponent<TurretBullet>();
        turretBulletScript.SetTarget(target, this); // Pass the turret reference
    }

    void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, Vector2.zero, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targettingRange;
    }

    public void OpenUpgradeUi()
    {
        upgradeUi.SetActive(true);
        UpdateUpgradeCostText();
    }

    public void CloseUpgradeUi()
    {
        upgradeUi.SetActive(false);
        UiManager.main.SetHoveringState(false);
    }

    public void UpgradeTurret()
    {
        int cost = CalculateCost();
        if (cost > LevelManager.main.currency)
        {
            ShowErrorMessage("Ghareebo(Not enough currency!)");
            return;
        }

        LevelManager.main.SpendCurrency(cost);

        level++;
        bulletPerSecond = CalculateBulletPerSecond();
        targettingRange = CalculateRange();
        UpdateUpgradeCostText();

        CloseUpgradeUi();
        Debug.Log("New BulletPerSecond: " + bulletPerSecond);
        Debug.Log("New Range: " + targettingRange);
        Debug.Log("New Cost: " + CalculateCost());

        // Update the range indicator size
        DrawRangeIndicator(targettingRange);
    }

    private void UpdateUpgradeCostText()
    {
        int cost = CalculateCost();
        upgradeCostText.text = $"Upgrade Cost: {cost}";
    }

    private void ShowErrorMessage(string message)
    {
        errorMessageText.text = message;
        StartCoroutine(ClearErrorMessageAfterDelay(2f)); // Clear message after 2 seconds
    }

    private IEnumerator ClearErrorMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        errorMessageText.text = string.Empty;
    }

    private int CalculateCost()
    {
        return Mathf.RoundToInt(upgradeCost * Mathf.Pow(level, 0.8f));
    }

    private float CalculateBulletPerSecond()
    {
        return bulletPerSecond * Mathf.Pow(level, 0.5f);
    }

    private float CalculateRange()
    {
        return targettingRange * Mathf.Pow(level, 0.4f);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse entered turret area.");
        lineRenderer.enabled = true;  // Show the range indicator
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse exited turret area.");
        lineRenderer.enabled = false; // Hide the range indicator
    }

    private void DrawRangeIndicator(float radius)
    {
        int segments = 50;  // Number of segments in the circle
        lineRenderer.positionCount = segments + 1;
        float angle = 0f;

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            // Update to work in 2D space (z=0)
            lineRenderer.SetPosition(i, new Vector3(x + transform.position.x, y + transform.position.y, 0));
            angle += 360f / segments;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, targettingRange);
    }
}
