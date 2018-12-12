using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : ExtendedMonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firingTransform;
    [SerializeField] private float fireCooldown = 0.5f;

    [SerializeField] public bool IsInCooldown { get; private set; } = false;

    void Start()
    {
        // Weapon is used as default firing transform
        if (firingTransform == null) firingTransform = transform;
    }

    /// <summary>
    /// Fire a projectile
    /// </summary>
    public void Fire(Vector2? targetPosition = null)
    {
        // Cannot be fired while in cooldown mode
        if (IsInCooldown) return;
        IsInCooldown = true;

        // TODO: Figure out how to set a parent to avoid cluttering editor UI (they do get deleted...)
        GameObject instance = Instantiate(projectilePrefab, firingTransform.position, transform.rotation);

        // Targeted projectiles
        if (targetPosition != null)
        {
            Projectile projectile = instance.GetComponent<Projectile>();
            projectile.Type = ProjectileType.TARGETED;
            projectile.TargetPosition = (Vector2) targetPosition;
        }

        // Start cooldown period
        Wait(fireCooldown, () => {
            IsInCooldown = false;
        });
    }
}
