using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : ExtendedMonoBehaviour
{
    [SerializeField] private CharacterMovementSettings Movement;
    [SerializeField] private CharacterMouseSettings Mouse;
    [SerializeField] private ProjectileWeapon Weapon;

    private Rigidbody2D rb;
    private Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotate player to match mouse target
        transform.rotation = MouseUtils.GetSlerpedAngleToMouse(transform, Mouse.RotationSlerpRatio * Time.deltaTime, -90f);

        // Calculate player movement in response to keyboard input
        // TODO: Handle stamina/energy drain
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = Movement.GetTargetVelocity(moveInput.normalized, isRunning);

        // Handle firing weapon
        if (Input.GetMouseButtonDown(0) && Weapon != null)
        {
            Weapon.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void FixedUpdate()
    {
        // Move character
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
