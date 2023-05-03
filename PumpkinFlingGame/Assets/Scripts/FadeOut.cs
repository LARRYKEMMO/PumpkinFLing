using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    Color TempColor;
    public GameObject FadeOutSquare;
    //float trans = 0.5f;
    int i;
    //float col = FadeOutSquare.GetComponent<Renderer> ().material.color;

    void Awake()
    {

        //StartCoroutine(FadeToBlack());
              
    }


    
    // Start is called before the first frame update
    void Start()
    {
        TempColor = FadeOutSquare.GetComponent<Renderer>().material.color;
        TempColor.a = 0f;
        FadeOutSquare.GetComponent<Renderer>().material.color = TempColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        //FadeOutSquare.GetComponent<Renderer>().material.color.a = 3;
    }

    public IEnumerator FadeToBlack()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.2f);
            TempColor.a += 0.45f;
            FadeOutSquare.GetComponent<Renderer>().material.color = TempColor;
        }
    }

   
}
