using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Character movement settings
/// </summary>
[Serializable]
public class CharacterMovementSettings
{
    [Header("Base Speed Settings")]
    public float Speed = 5f;
    public float RunMultiplier = 2.0f;

    [Header("Burst Settings")]
    public float BurstMultiplier = 4f;
    public float BurstLength = 2f;
    public float BurstTimeout = 10f;

    [Header("Key Bindings")]
    public KeyCode BurstKey = KeyCode.Space;
    public KeyCode RunKey = KeyCode.LeftShift;

    private float TargetSpeed;


    /// <summary>
    /// Get target speed from parameters and constraints
    /// </summary>
    /// <param name="moveInput">Movement input (from keyboard)</param>
    /// <param name="isRunning">Whether target is running</param>
    /// <returns>Target speed</returns>
    public float GetTargetSpeed(Vector2 moveInput, bool isRunning)
    {
        TargetSpeed = Speed;

        if (moveInput == Vector2.zero)
        {
            return 0f;
        }

        // TODO: Only enable while player has stamina
        if (isRunning)
        {
            TargetSpeed = Speed *= RunMultiplier;
        }

        // TODO: Disable burst mode
        /* if (Input.GetKeyDown(BurstKey) && false)
        {
            // TODO: Apply burst for length period
            TargetSpeed = Speed *= BurstMultiplier;

            // TODO: Disable burst for timeout period
        } */

        return TargetSpeed;
    }

    /// <summary>
    /// Get target velocity from parameters and constraints
    /// </summary>
    /// <param name="moveInput">Movement input (from keyboard)</param>
    /// <param name="isRunning">Whether target is running</param>
    /// <returns>Target velocity</returns>
    public Vector2 GetTargetVelocity(Vector2 moveInput, bool isRunning)
    {
        float targetSpeed = GetTargetSpeed(moveInput, isRunning);

        return moveInput * targetSpeed;
    }
}
