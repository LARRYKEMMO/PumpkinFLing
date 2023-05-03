using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(_player, Vector3.zero, Quaternion.identity);
            //gameOver = false;
            //_uiManager.HideTitleScreen();
        }
    }
}
