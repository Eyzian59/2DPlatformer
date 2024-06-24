using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private float xMovement;

    public bool grounded;

    // Update is called once per frame
    void Update()
    {
        xMovement = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xMovement * speed, rb.velocity.y);

        if(Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
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
