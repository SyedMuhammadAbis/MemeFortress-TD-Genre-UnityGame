using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    private bool isDestroyed = false;






    public void TakeDamage(int damage)               
    {
        hitPoints -= damage;

        if (hitPoints <= 0 && !isDestroyed)                                                           //i will make in future the dmage taken set to float  or not maybe i should go with the method of coc
        {
            EnemySpawner.onEnemyDestroy.Invoke();

            LevelManager.main.IncreaseCurrency(currencyWorth);


            isDestroyed =true;

            Destroy(gameObject);

        }
    }
  
}
