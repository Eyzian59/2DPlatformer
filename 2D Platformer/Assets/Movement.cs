using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;
    private float xInput;
    private bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }
}
