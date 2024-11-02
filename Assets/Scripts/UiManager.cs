using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager main;

    private bool isHoveringUi;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemiesAliveText;
    [SerializeField] private TextMeshProUGUI enemiesLeftToSpawnText;
    [SerializeField] private TextMeshProUGUI healthText; // Health display text
    [SerializeField] private GameObject gameOverPanel;   // Game Over screen panel
    [SerializeField] private TextMeshProUGUI gameOverMessage;

    private void Awake()
    {
        main = this;
        gameOverPanel.SetActive(false); // Hide Game Over UI at the start
    }

    public void SetHoveringState(bool state)
    {
        isHoveringUi = state;
    }

    public bool IsHoveringUi()
    {
        return isHoveringUi;
    }

    public void UpdateCountdown(float countdown)
    {
        countdownText.text = $"Time before wave starts: {countdown:F1} seconds";
    }

    public void UpdateWave(int wave)
    {
        waveText.text = $"Wave: {wave}";
    }

    public void UpdateEnemiesAlive(int enemiesAlive)
    {
        enemiesAliveText.text = $"Enemies Alive: {enemiesAlive}";
    }

    public void UpdateEnemiesLeftToSpawn(int enemiesLeftToSpawn)
    {
        enemiesLeftToSpawnText.text = $"Enemies Left to Spawn: {enemiesLeftToSpawn}";
    }

    // New method to update the health display
    public void UpdateHealthDisplay(int currentHealth)
    {
        healthText.text = $"Home Health: {currentHealth}";
    }

    // New method to show the Game Over screen
    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverMessage.text = "Game Over! Home has been destroyed.";
    }
}
