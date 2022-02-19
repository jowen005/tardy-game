using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detailSpawner : MonoBehaviour
{
    enum Object { ObstacleS, ObstacleM, ObstacleL, Scooter, Soda, BigBlue };
    public Vector2 screenBounds;

    public float spawnTimer;
    float sentBoost;
    public float timerReset;
    public Vector3 spawnPOS;
    float life;
    BoxCollider2D boxColl;
    public List<GameObject> spawnables = new List<GameObject>();
    public List<GameObject> spawnList = new List<GameObject>();
    public GameObject player;
    public float[] itemDists;
    public float[] itemDistResets=new float[2];
    Vector3 displacementChange;
    Vector3 finalPos;
    float oldX;
    float newX;
    // Start is called before the first frame update
    void Start()
    {
        displacementChange.x = 9.0f;
        displacementChange.y = -2.2f;
 itemDists = new float[2];
        for (int i = 0; i < 2; i++)
        {
            itemDists[i] = itemDistResets[i];
            oldX = transform.position.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        newX = XChange(ref oldX);
      for (int i=0; i<2; i++)
        {
            itemDists[i] -= newX;
           
            if (itemDists[i] < 0)
            {
                if (i == 0)
                {
                    TreePick(ref itemDists[i], itemDistResets[i]);
                }
                else if (i==1)
                {
                    finalPos = spawnables[3].transform.position;
                    finalPos.x = transform.position.x;
                    finalPos.x += displacementChange.x;
                    itemDists[1] = itemDistResets[1];
                    spawnList.Add(Instantiate(spawnables[3], finalPos, player.transform.rotation));
                }
              
            }
        }
      if (spawnList.Count > 0)
        {
            DespawnCheck(spawnList);
        }
     
    }
    void DespawnCheck(List<GameObject> list)
    {
        life = list[0].GetComponent<Lifetime>().life;
        if ((list[0].transform.position.x < (player.transform.position.x - 9.0f)) && (life > 1.0f))
        {
            Destroy(list[0]);
            list.RemoveAt(0);
        }
    }
    float XChange(ref float oldX)
    {
        float returnValue = transform.position.x - oldX;
        oldX = transform.position.x;
        return returnValue;
    }
  void TreePick(ref float timer, float reset)
    {
        int randint = Random.Range(1, 12);
        float randnum = randint * 0.1f;
        int randtree = Random.Range(0, 3);
        finalPos = spawnables[randtree].transform.position;
        finalPos.x = transform.position.x;
        finalPos.x += displacementChange.x;
        spawnList.Add(Instantiate(spawnables[randtree], finalPos, player.transform.rotation));
        timer = reset * randnum;
    }  
}
