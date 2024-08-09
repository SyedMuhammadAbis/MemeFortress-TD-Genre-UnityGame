using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeUiHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouse_over = false;
    public GameObject upgradeUi; // Reference to the Upgrade UI GameObject

    void Start()
    {
    }

    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        UiManager.main.SetHoveringState(true);
        if (upgradeUi != null)
        {
            upgradeUi.SetActive(true); // Ensure the UI is active when mouse is over
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        UiManager.main.SetHoveringState(false);
        if (upgradeUi != null)
        {
            upgradeUi.SetActive(false); // Deactivate the UI when mouse exits
        }
    }
}
