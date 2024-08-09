using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefab;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f; // the higher this number is the more enemies will be spawned per wave
    [SerializeField] private float enemiesPerSecondCap = 15f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent(); // we can also call this new unity event function in awake method

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;
    private float eps;
    private float countdown;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        UiManager.main.UpdateWave(currentWave);
        StartCoroutine(StartWave());
    }

    private void Update()
    {
        if (!isSpawning)
        {
            UiManager.main.UpdateCountdown(countdown);
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / eps) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
            UpdateUI();
        }
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }

        UpdateUI();
    }

    private IEnumerator StartWave()
    {
        countdown = timeBetweenWaves;
        while (countdown > 0)
        {
            yield return new WaitForSeconds(1f);
            countdown--;
            UiManager.main.UpdateCountdown(countdown);
        }

        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
        eps = EnemiesPerSecond();
        UpdateUI();
    }

    private void SpawnEnemy()
    {
        int index = Random.Range(0, enemyPrefab.Length);
        GameObject prefabToSpawn = enemyPrefab[index];
        Instantiate(prefabToSpawn, LevelManager.main.startpoint.position, Quaternion.identity);
        Debug.Log("Spawn Enemy");
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
    }

    private float EnemiesPerSecond()
    {
        return Mathf.Clamp(enemiesPerSecond * Mathf.Pow(currentWave, difficultyScalingFactor), 0f, enemiesPerSecondCap);
    }

    private void UpdateUI()
    {
        UiManager.main.UpdateWave(currentWave);
        UiManager.main.UpdateEnemiesAlive(enemiesAlive);
        UiManager.main.UpdateEnemiesLeftToSpawn(enemiesLeftToSpawn);
    }
}
