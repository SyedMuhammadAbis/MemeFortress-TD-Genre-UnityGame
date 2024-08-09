using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public Camera cam;
    private Vector2 mousePos;

    void Update()
    {
        // Update the mouse position every frame
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        // Calculate direction from the gun to the mouse
        Vector2 lookDir = mousePos - (Vector2)transform.position;

        // Calculate angle in degrees
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        // Set the rotation of the Transform component
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
