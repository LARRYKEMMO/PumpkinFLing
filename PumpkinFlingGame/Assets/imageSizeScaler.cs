using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imageSizeScaler : MonoBehaviour
{
   SpriteRenderer sr;
 void Start () {
  sr = GetComponent<SpriteRenderer> ();
  float xmas = Screen.width*Camera.main.orthographicSize*2.0f /(Screen.height*1.0f);//
  float yScale =Camera.main.orthographicSize*2.0f  / sr.GetComponent<Renderer>().bounds.size.y; 
  float xScale = 0;
  if (Screen.height > Screen.width)
      xScale = xmas / sr.GetComponent<Renderer>().bounds.size.x;
    else
      xScale = 1.5f; //for web view etc . you can change 1.5 according to you
  transform.localScale = new Vector3 (xScale,yScale,1);// I am using 2d so z doesn't needed.
 }
}
