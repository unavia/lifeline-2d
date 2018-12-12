using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projectile data
/// </summary>
[CreateAssetMenu(fileName = "Create Projectile", menuName = "Items/Projectile")]
public class ProjectileData : ScriptableObject
{
    public float Speed = 0;
    public bool HasLifetime = false;
    public float MaxLifetime = 0;

    public GameObject DestroyEffect;
    public AudioClip DestroySound;
}
