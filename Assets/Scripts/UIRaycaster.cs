using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class UIRaycaster : MonoBehaviour
{
    private EventSystem eventSystem;
    private PointerEventData pointerEventData;
    private List<RaycastResult> raycastResults;

    void Start()
    {
        eventSystem = EventSystem.current;
        pointerEventData = new PointerEventData(eventSystem);                                     //script for when i tap the ui the shooting and the shouting sound functions should not be called
        raycastResults = new List<RaycastResult>();
    }

    public bool IsPointerOverUIElement()
    {
        pointerEventData.position = Input.mousePosition;
        raycastResults.Clear();
        eventSystem.RaycastAll(pointerEventData, raycastResults);
        return raycastResults.Count > 0;
    }
}
