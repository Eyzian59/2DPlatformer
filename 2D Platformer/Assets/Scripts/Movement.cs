using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Animator animator;
    public float speed;
    public float jumpForce;
    private float xMovement;
    public bool grounded;
    private bool isFacingRight = true;
    public int cherries = 0;

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        Flip();

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
        animator.SetFloat("Speed", Mathf.Abs(xMovement));

        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if((isFacingRight && xMovement < 0f) || (!isFacingRight && xMovement > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Items")
        {
            Destroy(other.gameObject);
            cherries += 1;
        }
    }
}
