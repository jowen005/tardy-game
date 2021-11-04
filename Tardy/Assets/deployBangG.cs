using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBangG : MonoBehaviour
{
    public GameObject bang1Prefab;
    public float respawnTime = 2.0f;
    public Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(BangGround());
    }

    private void SpawnBuff()
    {
        GameObject a = Instantiate(bang1Prefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, -0.5f);
    }
    IEnumerator BangGround()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnBuff();
        }
    }
}
