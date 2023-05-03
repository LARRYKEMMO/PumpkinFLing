using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollideEvent : MonoBehaviour{

    private Vector3 finalPosition;

    private void Start()
    {
        finalPosition = new Vector3(5.5f, 3.0f, 0.0f);
    }
    private void Update()
    {
        if (gameObject.transform.position.x >= finalPosition.x)
        {
            SceneManager.LoadScene("PumpkinFlingGame");
        }
    }
}
