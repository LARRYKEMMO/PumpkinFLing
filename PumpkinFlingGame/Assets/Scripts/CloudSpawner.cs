using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CloudPrefab;
    private GameObject Cloud;
    private Vector3 OriginalPosition;
    private int XPosition = -400;
    void Start()
    {
    //    OriginalPosition = new Vector3(Random.Range(-19, 500), Random.Range(8, 500), 0);
        for(int i = 0; i < 20000; i++)
        {
            OriginalPosition = new Vector3(Random.Range(XPosition, 700), Random.Range(6, 500), 0);
            Cloud = Instantiate(CloudPrefab,OriginalPosition,Quaternion.identity);
            if(i % 10 == 0)
            {
                XPosition += 10;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
