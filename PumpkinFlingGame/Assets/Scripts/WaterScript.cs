using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GObject;
    public GameObject GObject2;
    public new AudioSource audio;
    private bool MoveBackward = false;
    private float OriginalX;
    int counter;
    void Start()
    {
        OriginalX = gameObject.transform.position.x;
        //audio = new AudioSource();
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(GObject.transform.position.x >= gameObject.transform.position.x)
        {
            gameObject.transform.position += new Vector3(2f,0f,0f); 
            GObject2.transform.position += new Vector3(2f, 0f, 0f);
        }
        
        if(MoveBackward == true && GObject.transform.position.x <= gameObject.transform.position.x)
        {
            if(GObject.transform.position.x >= OriginalX)
            {
                gameObject.transform.position -= new Vector3(2f, 0f, 0f);
                GObject2.transform.position -= new Vector3(2f, 0f, 0f);
            }
            else
            {
                MoveBackward = false;
            }
            
        }
        
    }

    public void SetMoveBackward()
    {
        MoveBackward = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && counter == 0)
        {
            counter++;
            audio.Play();
        }
    }

}
