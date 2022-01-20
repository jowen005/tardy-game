using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public Vector2 screenBounds;
    public float xstart;
    public float u_or_d;
    public int randnum;
    public float spawnTimer;
    public float timerReset;
    public Vector3 spawnPOS;
    BoxCollider2D boxColl;
    public GameObject obstacleL1;
    public GameObject obstacleS1;
    public GameObject obstacleM1;
    public GameObject soda;
    public GameObject bigBlue;
    public GameObject scooter;
    public List<GameObject> spawnables = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        timerReset = spawnTimer;
         xstart = transform.position.x;
         boxColl = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            randnum = Random.Range(0, 2);
            randnum *= 2;
            u_or_d =(float)randnum;
            u_or_d -= 2.2f;
            spawnPOS = transform.position;
            spawnPOS += new Vector3(5.0f, u_or_d, 0.0f);
            spawnTimer += timerReset;
            int xcount = Random.Range(1, 6);
            switch (xcount)
            {
                case 1:
                    spawnables.Add(Instantiate(obstacleL1,spawnPOS, transform.rotation));
                    break;
                case 2:
                    spawnables.Add(Instantiate(obstacleM1, spawnPOS, transform.rotation));
                    break;
                case 3:
                    spawnables.Add(Instantiate(obstacleS1, spawnPOS, transform.rotation));
                    break;
                case 4:
                    spawnables.Add(Instantiate(soda, spawnPOS, transform.rotation));
                    break;
                case 5:
                    spawnables.Add(Instantiate(bigBlue, spawnPOS, transform.rotation));
                    break;
                case 6:
                    spawnables.Add(Instantiate(scooter, spawnPOS, transform.rotation));
                    break;
            }
        }
        
    }
}
