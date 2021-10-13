using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //declaring variables
    public float currentX=0f;
    public float baseSpeed = .00001f;
    public float speedMulti = 1.0f;
    public float jumpForce = 11000.0f;
    public float speedBar = 100f;
    public bool isGrounded;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {//declaring the rigidbody variable
        rb = GetComponent<Rigidbody2D>();
   
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float movement = baseSpeed * speedMulti;
        transform.Translate(movement, 0.0f, 0.0f);

        //testing if the player is on the ground and if the W key is pressed
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
         
            jump();
        }
        multInc();
    }
    //the function to detect if the player is touching the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    //the jumping function
    void jump()
    {
        //adding to the overall velocity to jump
       rb.velocity += Vector2.up * (jumpForce);
        isGrounded = false;
    }
 //the function to slowly accelerate   
    void multInc()
    {
        currentX = transform.position.x;
       
       
        if (currentX >= speedBar)
        {
            speedBar += 100f;
            speedMulti += .01f;
        }
        currentX = transform.position.x;
    }
    
}
