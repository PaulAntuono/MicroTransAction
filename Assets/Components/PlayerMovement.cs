using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float Move;
    public float jump;
    public bool isJumping;

    private Rigidbody2D rb;
    public Animator animator;

    private Vector3 originalScale; // Store the original scale

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale; // Store the original scale at the start
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        // Update velocity based on the direction
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        // Update animation speed based on the absolute value of Move
        animator.SetFloat("Speed", Mathf.Abs(speed * Move));

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            animator.SetBool("IsJumping", true);
        }

        // Flip the player sprite if moving in the opposite direction
        if (Move > 0)
        {
            transform.localScale = originalScale; // Use the original scale for right movement
        }
        else if (Move < 0)
        {
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); // Flip for left movement
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }
}
