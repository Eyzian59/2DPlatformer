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
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("isJumping", true);
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
