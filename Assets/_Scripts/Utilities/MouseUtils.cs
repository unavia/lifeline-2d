using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mouse utilities
/// </summary>
public abstract class MouseUtils
{
    /// <summary>
    /// Get angle to the mouse position
    /// </summary>
    /// <param name="sourcePosition">Source transform position</param>
    /// <param name="angleOffset">Calculate offset for angle (Unity grid starts in right axis)</param>
    /// <returns>Euler angle to mouse</returns>
    public static Quaternion GetAngleToMouse(Vector2 sourcePosition, float angleOffset = 0f)
    {
        return GetAngleToTarget(sourcePosition, Input.mousePosition, angleOffset);
    }

    /// <summary>
    /// Get angle to a target position
    /// </summary>
    /// <param name="sourcePosition">Source transform position</param>
    /// <param name="targetPosition">Target transform position</param>
    /// <param name="angleOffset">Calculate offset for angle (Unity grid starts in right axis)</param>
    /// <returns>Euler angle to target</returns>
    public static Quaternion GetAngleToTarget(Vector2 sourcePosition, Vector2 targetPosition, float angleOffset = 0f)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(targetPosition);
        Vector2 offset = new Vector2(mousePosition.x - sourcePosition.x, mousePosition.y - sourcePosition.y);

        // Angle offset enables proper rotation for "up" based rotation (angle starts from right axis)
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg + angleOffset;
        return Quaternion.Euler(0, 0, angle);
    }

    /// <summary>
    /// Get slerped angle to the mouse position (transitions smoothly)
    /// </summary>
    /// <param name="sourcePosition">Source transform position</param>
    /// <param name="slerpRatio">Ratio to slerp angle transition</param>
    /// <param name="angleOffset">Calculate offset for angle (Unity grid starts in right axis)</param>
    /// <returns>Slerped euler angle to mouse</returns>
    public static Quaternion GetSlerpedAngleToMouse(Transform sourcePosition, float slerpRatio = 0f, float angleOffset = 0f)
    {
        return GetSlerpedAngleToTarget(sourcePosition, Input.mousePosition, slerpRatio, angleOffset);
    }

    /// <summary>
    /// Get slerped angle to a target position (transitions smoothly)
    /// </summary>
    /// <param name="sourcePosition">Source transform position</param>
    /// <param name="targetPosition">Target transform position</param>
    /// <param name="slerpRatio">Ratio to slerp angle transition</param>
    /// <param name="angleOffset">Calculate offset for angle (Unity grid starts in right axis)</param>
    /// <returns>Slerped euler angle to target</returns>
    public static Quaternion GetSlerpedAngleToTarget(Transform sourcePosition, Vector2 targetPosition, float slerpRatio = 0f, float angleOffset = 0f)
    {
        Quaternion angleToTarget = GetAngleToTarget(sourcePosition.position, targetPosition, angleOffset);

        // Lerping enables smoothly rotating character towards target over time
        return Quaternion.Slerp(sourcePosition.rotation, angleToTarget, slerpRatio);
    }

}
