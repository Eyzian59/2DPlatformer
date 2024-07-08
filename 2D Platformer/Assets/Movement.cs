using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float speed;
    public float jumpForce;
    private float xMovement;
    public bool grounded;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    void FixedUpdate()
    {
        xMovement = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(xMovement));

        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
