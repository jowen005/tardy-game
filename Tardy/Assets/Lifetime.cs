using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float life;
    // Start is called before the first frame update
    void Start()
    {
        life = 0;
    }

    // Update is called once per frame
    void Update()
    {
        life += Time.deltaTime;
    }
}
