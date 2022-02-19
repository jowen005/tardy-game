using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    public GameObject player;
    public float distancediff;
    public float playerx;
    public float objx;
    float timeAlive;
    
    // Start is called before the first frame update
    void Start()
    {
        distancediff = 19.0f;
        timeAlive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        objx = transform.position.x;
        playerx = player.transform.position.x+distancediff;
        if ((timeAlive>1)&&((transform.position.x+distancediff)<player.transform.position.x))
        {
             Destroy(this.gameObject);
           
        }
    }
}
