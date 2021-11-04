using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public Vector2 screenBounds;
    public float xstart;
    BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Start()
    {
        xstart = transform.position.x;
        boxColl = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(transform.position.x < xstart -10)
        {
            
        }*/
        
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
