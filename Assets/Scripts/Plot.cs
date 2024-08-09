using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private Color startColour;
    private GameObject towerObj;
    public Turret turret;



    [Header("references")]
    [SerializeField] private SpriteRenderer sp;
    [SerializeField] private Color hoverColor;


    





    void Start()
    {
        startColour = sp.color;

    }



    private void OnMouseEnter()
    {
        sp.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sp.color = startColour; 

    }

    private void OnMouseDown()
    {
        if (towerObj != null) 
        {
            if (UiManager.main.IsHoveringUi()) return;
            

            turret.OpenUpgradeUi();




            return;
        }



        Tower towerToBuild  = BuildManager.main.GetSelectedTower();
        
        if (towerToBuild.cost > LevelManager.main.currency)
        {
            Debug.Log("You cant afford this toewer ");
            return;

        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);



        towerObj = Instantiate(towerToBuild.prefab, transform.position,Quaternion.identity);

        turret = towerObj.GetComponent<Turret>();


    }



}
