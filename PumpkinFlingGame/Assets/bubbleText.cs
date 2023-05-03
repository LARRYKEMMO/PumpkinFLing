using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubbleText : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        bubbleText bubbleText = GetComponent<bubbleText>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // Canvas canvas = GetComponent<Canvas>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (MainManager.previousDistance > 10 && MainManager.previousDistance < 100)
        {
            spriteRenderer.enabled = true;
            text.text = "What Happened?";
        }
        else if (MainManager.previousDistance >= 100 && MainManager.previousDistance < 200)
        {
            spriteRenderer.enabled = true;
            text.text = "Not Bad Keep Trying";
        }
        
        else if (MainManager.previousDistance >= 200 && MainManager.previousDistance < 300)
        {
            spriteRenderer.enabled = true;
            text.text = "WOW Nice Shot!";
        }
        else if (MainManager.previousDistance >= 300 && MainManager.previousDistance < 500)
        {
            spriteRenderer.enabled = true;
            text.text = "That Was Amazing!";
        }
        else if (MainManager.previousDistance >= 500 && MainManager.previousDistance < 50000000)
        {
            spriteRenderer.enabled = true;
            text.text = "IS THAT A NEW RECORD?";
        }
    }
}
