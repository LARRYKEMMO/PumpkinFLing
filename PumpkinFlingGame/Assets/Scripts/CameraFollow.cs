using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public Vector3 offest;
    public float damping;

    private Vector3 velocity = Vector3.zero;
    private Vector3 movePosition;
    private bool transitionCamera = false;
    public float transitionSpeed = 20;

    Vector3 OriginalPosition;
    private void Start()
    {
        OriginalPosition = transform.position;     
        
        
    }
    void FixedUpdate()
    {
        if(gameObject != null)
        {
            var playerList = GameObject.FindGameObjectsWithTag("Player");
            if(playerList.Length > 0)
            {
                player = playerList[0].transform;
            }
            //player = GameObject.FindWithTag("Player").transform;
        }        
        

        if (player != null)
        {
            movePosition = player.position + offest;

            // Makes sure we never see underneath the ground anymore after shooting
            if(movePosition.y < 0)
            {
                movePosition.y = 0;
            }
            // follows the object
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);

            
        }
        
    }


    private void Update()
    {
        //let's use this only for debug purposes
        //after works, let's give this a timer

        // checks if camera can move back to initial position
        if (transitionCamera)
        {
            // gradually reduces the x component
            if (transform.position.x > OriginalPosition.x)
            {
                transform.position = new Vector3(transform.position.x - (transitionSpeed * Time.deltaTime), transform.position.y , transform.position.z);
            }
            
            // gradually reduces the y component
            if (transform.position.y > OriginalPosition.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (transitionSpeed * Time.deltaTime), transform.position.z);

            }
            // Debug.Log("here");
            if (transform.position.x <= OriginalPosition.x && transform.position.y <= OriginalPosition.y) transitionCamera = false; // stop moving
        }
        // Input for camera panning
      //  if (Input.GetKeyDown(KeyCode.Space)){
       //     Camera.main.gameObject.transform.position = OriginalPosition;
       // }
    }

    public void resetCamera()
    {
        Invoke("realReset", 5f); // resets camera after 2.5 seconds
    }

    public void realReset()
    {
        transitionCamera = true; // resets transitionCamera to true
        
        //Camera.main.gameObject.transform.position = OriginalPosition;
    }


}