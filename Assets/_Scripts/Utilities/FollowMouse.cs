using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follow the mouse at an optional offset
/// </summary>
public class FollowMouse : MonoBehaviour
{
    public bool Overlay = false;
    public Vector2 Offset = Vector2.zero;

    // Slerp (smoothing) settings
    public bool ShouldSlerp = true;
    public float Speed = 20f;

    void Update()
    {
        // Ensure following item always tracks mouse (at optional offset)
        if (Overlay)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;

            if (ShouldSlerp)
            {
                transform.position = Vector2.Lerp(transform.position, mousePosition, Speed * Time.deltaTime);
            }
            else
            {
                transform.position = mousePosition;
            }
        }
    }
}
