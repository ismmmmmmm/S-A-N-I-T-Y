using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform groundCheck;
    private Animator animator;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isGrabbing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if player is grounded
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, LayerMask.GetMask("Ground"));

        // Movement
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (isGrabbing)
        {
            isMovingRight = false;
            isMovingLeft = false;
        }
        else
        {
            if (moveDirection > 0)
            {
                isMovingRight = true;
                isMovingLeft = false;
            }
            else if (moveDirection < 0)
            {
                isMovingRight = false;
                isMovingLeft = true;
            }
            else
            {
                isMovingRight = false;
                isMovingLeft = false;
            }
        }

        animator.SetBool("isMovingRight", isMovingRight);
        animator.SetBool("isMovingLeft", isMovingLeft);
        animator.SetBool("isGrabbingTrue", isGrabbing);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check collision's layer or tag
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cliff"))
        {
            isGrabbing = true;
            isMovingLeft = false;
            isMovingRight = false;
            Debug.Log("Entering a cliff area.");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check collider's layer or tag
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cliff"))
        {
            isGrabbing = false;
            Debug.Log("Exited a cliff area.");
        }
    }
}
