using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class PlayerGFXDirection : MonoBehaviour
{
    public Animator anim;
    //private string WALK_ANIMATION = "Walk";
    private Rigidbody2D myBody;
    public AIPath aiPath;
    // Update is called once per frame

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatePlayer();
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        } else if (aiPath.desiredVelocity.x < 0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1.0f);
        }
    }
    void AnimatePlayer()
    {
        //anim.SetBool(WALK_ANIMATION, true);
    }
}
