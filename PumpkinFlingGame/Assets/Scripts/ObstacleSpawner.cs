using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    
    public GameObject obstacle;
    private GameObject inst;
    //private int tally = 0;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawns;
    private float SpawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > SpawnTime && MainManager.distance > 50 && MainManager.ballStopped == false)
        {

            Spawn();
            SpawnTime = Time.time + timeBetweenSpawns;
        
        }
        
    }

    void Spawn()
    {
        
        float X = Random.Range(minX, maxX);
        float Y = Random.Range(minY, maxY);
        inst = Instantiate(obstacle, transform.position + new Vector3(X, Y, 0), transform.rotation);
        List<GameObject> IList = new List<GameObject>();
     
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "booster")
        {
            Destroy(gameObject);
        }
    }






}
