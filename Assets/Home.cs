using UnityEngine;

public class Home : MonoBehaviour
{
    public int startingHealth = 10;
    private int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
        UiManager.main.UpdateHealthDisplay(currentHealth); // Initial health display
    }

    public void TakeDamage()
    {
        currentHealth--;
        UiManager.main.UpdateHealthDisplay(currentHealth); // Update UI whenever damage is taken
        Debug.Log("Home health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Home is destroyed!");
            UiManager.main.ShowGameOver(); // Show Game Over screen
        }
    }
}
