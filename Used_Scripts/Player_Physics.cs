using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Physics : MonoBehaviour
{
    public float jumpForce = 7f;
    private bool isGrounded;
    private Rigidbody2D rb;
    private Player_Animator playerAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        playerAnimator = GetComponent<Player_Animator>();
        rb.freezeRotation = true; // Zablokowanie obrotu obiektu
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            playerAnimator.SetIsJumping(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnimator.SetIsJumping(false);
        }
    }
}
