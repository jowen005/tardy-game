using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  /*Currently the forward movement works, but 
   * the player1 wont register when it touches the ground
   */

    public float baseSpeed = .00001f;
    public float speedMulti = 1.0f;
    public float jumpForce = 11000.0f;
    public bool isGrounded;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * (baseSpeed * speedMulti);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            jump();
        }
        else
        {
            
        }
    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    void jump()
    {

       rb.velocity += Vector2.up * (jumpForce);
        isGrounded = false;
    }
    /*
      private void OnCollision2D(Collision2D other)
      {
          if (other.CompareTag("Ground"))
          {
              isGrounded = true;
              Debug.Log("Triggered by Ground");
          }
      }*/

}
