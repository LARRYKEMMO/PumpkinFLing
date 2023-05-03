using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Assets.HeroEditor.Common.Scripts.Common;

public class BallScript : MonoBehaviour
{

    // Start is called before the first frame update
    private CameraFollow cameraScript;
    private CannonManager cannonScript;
    private WaterScript waterScript;
    private float delay = 3f;
    private float timeElapsed;
    bool touchGround;
    private void Start()
    {
        touchGround = false;
        cannonScript = FindObjectOfType<CannonManager>();
        cameraScript = FindObjectOfType<CameraFollow>();
        waterScript = FindObjectOfType<WaterScript>();
    }
    // Update is called once per frame
    void Update()
    {
       // Debug.Log(touchGround);
        if (touchGround)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > delay)
            {
                reset();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   // Handles collision between the ground and pumpkin 
        if (collision.gameObject.tag == "GroundLayer" || collision.gameObject.tag == "Water")
        {
            
            MainManager.ballStopped = true;
            // Increase mass of ball
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            
            rb.gravityScale *= 5;
            rb.mass *= 10;
            Destroy(gameObject,3);
            touchGround = true;
            //Debug.Log(touchGround);
            //gameObject.GetComponent<CircleCollider2D>().SetActive(false);
            // reset();
        }
    }

   

    public void SetEverything()
    {
        cannonScript.SetFired();
       // Debug.Log(MainManager.setScore);
        if (MainManager.setScore == false)
        {
            setScoreLater();
        }

    }

    public void setScoreLater()
    {
        cannonScript.SetScore();
        MainManager.setScore = true;
    }

    public void reset()
    {
        //Debug.Log("Start of reset");
        SetEverything();
        SceneManager.LoadScene("PumpkinFlingGame");
        //Debug.Log("End of reset");
    }

   

}
