using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Projectile types
/// </summary>
public enum ProjectileType
{
    LIFETIME,
    TARGETED
}


public class Projectile : ExtendedMonoBehaviour
{
    // Maximum projectile lifetime (even if targeted)
    public float MAX_PROJECTILE_LIFETIME = 10f;

    public ProjectileData Data;

    public ProjectileType Type = ProjectileType.LIFETIME;
    public Vector2 TargetPosition;

    private void Start()
    {
        if (Data == null) Data = new ProjectileData();

        // Configure lifecycle for non-targeted projectiles
        //   NOTE: Causes immediate destruction for non-targeted projectiles with no lifetime
        if (Type == ProjectileType.LIFETIME)
        {
            Wait(Data.MaxLifetime, () => {
                DestroyProjectile();
            });
        }
        // Even targeted projectiles have a maximum lifetime
        else if (Type == ProjectileType.TARGETED)
        {
            Wait(MAX_PROJECTILE_LIFETIME, () => {
                DestroyProjectile();
            });
        }
    }

    void Update()
    {
        // Non-targeted projectiles travel until they expire
        if (Type == ProjectileType.LIFETIME)
        {
            transform.Translate(Vector2.up * Data.Speed * Time.deltaTime);
        }
        // Targeted projectiles travel until they reach their target
        else if (Type == ProjectileType.TARGETED)
        {
            Vector2 pathPosition = Vector2.MoveTowards(transform.position, TargetPosition, Data.Speed * Time.deltaTime);
            transform.position = pathPosition;

            if (Vector2.Distance(pathPosition, TargetPosition) < 0.01f)
            {
                DestroyProjectile();
            }
        }
    }

    /// <summary>
    /// Destroy the projectile after it has reached it's lifetime
    /// </summary>
    private void DestroyProjectile()
    {
        // Display particle effect when lifetime expires
        if (Data.DestroyEffect != null)
        {
            Instantiate(Data.DestroyEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
