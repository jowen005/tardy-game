using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
  /*Currently the forward movement, but 
   * the player1 wont register when it touches the ground
   */

    public float baseSpeed = .00001f;
    public float speedMulti = 1.0f;
  
    public bool isGrounded;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    
        rb.velocity = Vector2.right* (baseSpeed * speedMulti);
    }
  private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Ground")
        {
            isGrounded = true;
            Debug.Log("Triggered by Ground");
        }
    }
   
}
