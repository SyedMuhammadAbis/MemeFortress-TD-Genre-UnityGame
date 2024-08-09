using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager main;

    bool isHoveringUi;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemiesAliveText;
    [SerializeField] private TextMeshProUGUI enemiesLeftToSpawnText;

    private void Awake()
    {
        main = this;
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
}
