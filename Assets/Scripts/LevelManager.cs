using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform[] path;
    public Transform startpoint;
    public Home home; // Reference to the Home script

    public int currency;

    void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 100;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= currency)
        {
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You do not have enough currency to purchase this item");
            return false;
        }
    }

    public void EnemyReachedHome()
    {
        if (home != null)
        {
            home.TakeDamage(); // Call TakeDamage when an enemy reaches the home
        }
    }
}
