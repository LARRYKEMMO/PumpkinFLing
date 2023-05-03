using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BounceCollideObstacle : MonoBehaviour
{
    public new AudioSource audio;
    private bool hitObject = false;
    private GameObject ball;
    [SerializeField] float boostX, boostY;
    [SerializeField] Vector2 applyForce;

    void Start()
    {
        applyForce = new Vector2(boostX, boostY);
    }
    void Update()
    {
        if (hitObject)
        {
            //ball.gameObject.transform.position = new Vector2(ball.gameObject.transform.position.x + (boostX / 4), ball.gameObject.transform.position.y + (boostY / 4));
            ball.GetComponent<Rigidbody2D>().AddForce(applyForce, ForceMode2D.Impulse);
            hitObject = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audio.Play();
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null && hitObject == false)
            {
                ball = collision.gameObject;
                hitObject = true;
                StartCoroutine(waitToCollide());
            }
           
        }
       
    }

    IEnumerator waitToCollide()
    {
        yield return new WaitForSeconds(1);
        hitObject = false;
    }
}
