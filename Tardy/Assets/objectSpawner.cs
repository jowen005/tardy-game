using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    enum Object { ObstacleS, ObstacleM, ObstacleL, Scooter, Soda, BigBlue };
    public Vector2 screenBounds;
    public float xstart;
    public float u_or_d;
    float udOld;
    public int randnum;
    public float spawnTimer;
    float sentBoost;
    public float timerReset;
    public Vector3 spawnPOS;
    BoxCollider2D boxColl;
    public GameObject obstacleL1;
    public GameObject obstacleS1;
    public GameObject obstacleM1;
    public GameObject obstacleL2;
    public GameObject obstacleS2;
    public GameObject obstacleM2;
    public GameObject soda;
    public GameObject bigBlue;
    public GameObject scooter;
    public List<GameObject> spawnables = new List<GameObject>();
    int xcount;

    // Start is called before the first frame update
    void Start()
    {
        udOld = 0;
        sentBoost = 0;
        timerReset = spawnTimer;
         xstart = transform.position.x;
         boxColl = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer<= 0)
        {
            
            if (timerReset > 1.2f)
            {
                timerReset -= 0.1f;
            }
            randnum = Random.Range(0, 2);
            randnum *= 2;
            u_or_d =(float)randnum;
            u_or_d -= 2.3f;

            if ((udOld-u_or_d>-0.1) && (udOld-u_or_d<0.1))
            {
                Random.InitState(Time.frameCount);
                randnum = Random.Range(0, 2);
                randnum *= 2;
                u_or_d = (float)randnum;
                u_or_d -= 2.2f;
            }
                udOld = u_or_d;
            spawnPOS = transform.position;
            spawnPOS += new Vector3(5.0f, u_or_d, 0.0f);
            spawnTimer += timerReset;
            if (sentBoost > 0.7f)
            {
                xcount = Random.Range(1, 19);
            }
            else
            {
                 xcount = Random.Range(1, 10);
            }
            switch (xcount)
            {
                case 1:
                case 2:
                case 3:
                    Spawner(spawnPOS, Object.ObstacleL);
                    sentBoost = 1.0f;
                    break;
                case 4:
                case 5:
                case 6:
                    Spawner(spawnPOS, Object.ObstacleM);
                    sentBoost = 1.0f;
                    break;
                case 7:
                case 8:
                case 9:
                    Spawner(spawnPOS, Object.ObstacleS);
                    sentBoost = 1.0f;
                    break;

                case 10:
                case 11:
                    Spawner(spawnPOS, Object.Soda);
                    sentBoost = 0.5f;
                    break;
                case 12:

                    Spawner(spawnPOS, Object.BigBlue);
                    sentBoost = 0.5f;
                    break;
                case 13:
                case 14:
                    Spawner(spawnPOS, Object.Scooter);
                    sentBoost = 0.5f;
                    break;
                default:
                    sentBoost = 0.5f;
                    break;
            }
         spawnTimer*=sentBoost*Random.Range(1.0f, 1.4f);
        }
        
    }
    void Spawner(Vector3 spawnPOS, Object type)
    {
        switch (type)
        {
            case Object.ObstacleS:
                if (spawnPOS.y > 0)
                {
                    spawnables.Add(Instantiate(obstacleS2, spawnPOS, transform.rotation));
                }
                else
                {
                    spawnables.Add(Instantiate(obstacleS1, spawnPOS, transform.rotation));
                }
                break;
            case Object.ObstacleM:
                if (spawnPOS.y > 0)
                {
                    spawnables.Add(Instantiate(obstacleM2, spawnPOS, transform.rotation));
                }
                else
                {
                    spawnables.Add(Instantiate(obstacleM1, spawnPOS, transform.rotation));
                }
                break;
            case Object.ObstacleL:
            if (spawnPOS.y > 0)
                {
                    spawnables.Add(Instantiate(obstacleL2, spawnPOS, transform.rotation));
                }
            else{ 
                    spawnables.Add(Instantiate(obstacleL1, spawnPOS, transform.rotation)); 
                }
                break;
            case Object.Scooter:
                spawnables.Add(Instantiate(scooter, spawnPOS, transform.rotation));
                break;
            case Object.Soda:
                spawnables.Add(Instantiate(soda, spawnPOS, transform.rotation));
                break;
            case Object.BigBlue:
                spawnables.Add(Instantiate(bigBlue, spawnPOS, transform.rotation));
                break;
        }

    }
}

