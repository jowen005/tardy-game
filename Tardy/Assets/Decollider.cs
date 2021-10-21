using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decollider : MonoBehaviour
{
    BoxCollider2D boxColl;
  
    // Start is called before the first frame update
    void Start()
    {
        boxColl = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        boxColl.isTrigger = true;
    }
 }
