using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject fruitPf;
  
    float maxScope = -400f;
    float minScope = 400f;

    void Start()
    {
        StartCoroutine(spawnFruit());
    }

    //spawn fruit
    IEnumerator spawnFruit(){
        yield return new WaitForSeconds(Random.Range(0f,2f));
  
        GameObject newfruitOb = Instantiate(fruitPf, new Vector2(Random.Range(minScope,maxScope) , 600),Quaternion.identity );
        newfruitOb.transform.SetParent(GameObject.FindGameObjectWithTag("spawn").transform, false);
        StartCoroutine(spawnFruit());

    }
}
