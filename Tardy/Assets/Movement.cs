using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    //declaring variables
    public float currentX=0f;
    public float baseSpeed = .00001f;
    public float speedMulti = 1.0f;
    public float jumpForce = 11000.0f;
    public float speedBar = 100f;
    public float speedReduc, extrTime;
    public float boostTimer = 2.0f;
    public float dTimer = 10.0f;
    public float bTime = 0.0f;
    public float dTime = 0.0f;
    public bool isGrounded, isCeiling, hasScooter, hasBoost, hasDefense;
    Rigidbody2D rb;
    BoxCollider2D boxColl;
    // Start is called before the first frame update
    void Start()
    {//declaring the rigidbody variable
        rb = GetComponent<Rigidbody2D>();
        boxColl = gameObject.GetComponent<BoxCollider2D>();
        Application.targetFrameRate = 60;


    }
    
    // Update is called once per frame
    void Update()
        
    {
    if (speedMulti <= 0.1f)
        {
            speedMulti = 0.1f;
        }
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
        
        if (hasBoost == true)
        {
            hasBoost=BuffCntdwn(bTime, boostTimer,2f, 1);
        }
        if (hasDefense == true)
        {
            hasDefense = BuffCntdwn(dTime, dTimer, 0.0f, 2);
        }
     
    }
    //the function to detect what the player is touching
    void OnCollisionEnter2D(Collision2D collision)
    {
        //detects what it touches
        switch (collision.gameObject.tag)
        {
            case "Ground":
                isGrounded = true;
                isCeiling = false;
                break;
            case "Ceiling":
                 isCeiling = true;
                isGrounded = false;
                break;
           
        }

    }
    //the jumping function
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ObstacleL":
                ObstacleHit(0.1f);
                break;
            case "ObstacleM":
                ObstacleHit(0.05f);
                break;
            case "ObstacleS":
                ObstacleHit(0.01f);
                break;
            case "buffScooter":
                hasScooter = true;
                baseSpeed += speedReduc;
                break;
            case "buffBoost":
                hasBoost = true;
                speedMulti += 2f;
                boxColl.size = new Vector2(2.0f, 0.64f);
                break;
            case "buffDefense":
                hasDefense = true;
                break;
        }
    }
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
        //the code to pass through the ceiling
        if (coll.gameObject.tag == "Ceiling")
        {
            boxColl.isTrigger = false;
        }
    }
    void ObstacleHit(float damage)
    {
        if (hasScooter == true)
        {
            baseSpeed -= speedReduc;
            hasScooter = false;
        }
        if (hasBoost == false)
        {
            if (hasDefense == true)
            {
                speedMulti -= (damage / 2);
            }
            else
            {
                speedMulti -= damage;
            }
        }
    }
    bool BuffCntdwn(float timeMax, float clockTime, float speedReduction, int timerType)
    {
        if (timerType == 1)
        {
            bTime += Time.deltaTime;
        }
        else if (timerType == 2)
        {
            dTime += Time.deltaTime;
        }
        if (timeMax<clockTime)
            {
                return true;
            }
            else
        {
            switch (timerType)
            {
                case 1:
                    boxColl.size = new Vector2(0.64f, 0.64f);
                    bTime = 0;
                    break;
                case 2:
                    dTime = 0;
                    break;
            }
                speedMulti -= speedReduction;
                return false;
        }
       
    }
}
