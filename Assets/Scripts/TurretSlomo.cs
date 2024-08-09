using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretSlomo : MonoBehaviour
{

    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float targettingRange = 5f;
    [SerializeField] private float attacksPerSecond = 4f;
    [SerializeField] private float freezeTime = 1f;

    private float timeUntilFire;



    void Update()
    {

       
         timeUntilFire += Time.deltaTime;


         if (timeUntilFire >= 1f / attacksPerSecond)
         {

            FreezeEnemies();
            timeUntilFire = 0f;
         }
    
    }
    void FreezeEnemies()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targettingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0 )
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                EnemyMovement em = hit.transform.GetComponent<EnemyMovement>();
                
                em.Updatespeed(0.5f);                                             // dee wajay na ba toloo type enemies speed .5f shee kho da ba future kay change kon sa enemy wala kom default speed day gha dee banday divide kon dee sa ba bya dasay washee sa speed ba een kaam shee or you oora movement ba een na wee

                StartCoroutine(ResetEnemySpeed(em));

            }
        }
    }

    private IEnumerator ResetEnemySpeed(EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeTime);

        em.ResetSpeed();
    }

    private void OnDrawGizmosSelected()
    {
#if UNITY_EDITOR
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, targettingRange);                  
#endif
    }
}
