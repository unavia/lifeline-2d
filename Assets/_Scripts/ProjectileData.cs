using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectile data
/// </summary>
[CreateAssetMenu(fileName = "Create Projectile", menuName = "Items/Projectile")]
public class ProjectileData : ScriptableObject
{
    [Header("Properties")]
    public float Speed = 0;
    public bool HasLifetime = false;
    public float MaxLifetime = 0;

    [Header("Effects")]
    public GameObject DestroyEffect;
    public AudioClip DestroySound;
    public AudioClip LaunchSound;
}
