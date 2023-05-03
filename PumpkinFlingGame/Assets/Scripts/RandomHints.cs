using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomHints : MonoBehaviour
{

    public Text hintText;
    

    public void onPress()
    {
        float randomNumber = Random.Range(1,4);

        if(randomNumber == 1)
        {
            hintText.text = "Hello Friends";
        }else if(randomNumber == 2)
        {
            hintText.text = "Press space to jump";
        }else if (randomNumber == 3){
            hintText.text = "Press the launch button to shoot the cannon";
        }
        
       // Debug.Log(randomNumber);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
