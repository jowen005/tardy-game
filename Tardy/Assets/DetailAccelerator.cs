using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailAccelerator : MonoBehaviour
{
    public GameObject player;
  
    public float objectMulti;
    public float finalSpeed;
    public float baseSpeed;
    public float speedMulti;
    Movement pspeed;
    // Start is called before the first frame update
    void Start()
    {
    
       
    }

    // Update is called once per frame
    void Update()
    {
        Movement pspeed = player.GetComponent<Movement>();
        baseSpeed = pspeed.baseSpeed;
         speedMulti = pspeed.speedMulti;
        finalSpeed = speedMulti * baseSpeed * objectMulti;
        transform.Translate(finalSpeed, 0.0f, 0.0f);
    }
}
