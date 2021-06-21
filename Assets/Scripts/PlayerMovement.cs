using System;
using System.Collections;
using System.Collections.Generic;
using Packages.Rider.Editor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public Transform feet;
    public LayerMask groundLayers;
    [HideInInspector] public bool isFacingRight = true;

    private float mx;
    public float jumpPower = 20;
    private void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        
        // flips to face the right direction
        if (mx > 0.05f)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            isFacingRight = true;
        }
        else if (mx < 0f)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            isFacingRight = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Jump()
    {
        Vector2 movement = new Vector2(rb.velocity.x, jumpPower);
        rb.velocity = movement;
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
        if (groundCheck != null)
        {
            return true;
        }

        return false;
    }
}
