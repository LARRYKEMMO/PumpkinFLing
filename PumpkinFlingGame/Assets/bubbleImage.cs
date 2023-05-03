using Assets.HeroEditor.Common.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubbleImage : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //public Text text;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
       // text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (MainManager.showBubble == true)
       // {
        //    spriteRenderer.enabled = true;
           // text.SetActive(true);
        //}
        
    }
}
