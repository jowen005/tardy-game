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
    public bool isGrounded, isCeiling;
    Rigidbody2D rb;
    BoxCollider2D boxColl;
    // Start is called before the first frame update
    void Start()
    {//declaring the rigidbody variable
        rb = GetComponent<Rigidbody2D>();
        boxColl = gameObject.GetComponent<BoxCollider2D>();


    }
    
    // Update is called once per frame
    void Update()
    {
        float movement = baseSpeed * speedMulti;
        transform.Translate(movement, 0.0f, 0.0f);
        if (Input.GetKeyDown(KeyCode.S) && (isCeiling == true))
        {
            boxColl.isTrigger = true;
        }
        //testing if the player is on the ground and if the W key is pressed
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
         
            jump();
            boxColl.isTrigger = true;
        }
        multInc();
    }
    //the function to detect if the player is touching the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isCeiling = false;
        }
        if (collision.gameObject.tag == "Ceiling")
        {
            isCeiling = true;
            isGrounded = false;
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
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ceiling")
        {
            boxColl.isTrigger = false;
        }
    }
}
