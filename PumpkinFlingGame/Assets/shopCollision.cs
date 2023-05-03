using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopCollision : MonoBehaviour
{
    public Text text;
    public GameObject bubble;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = bubble.GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAmy") || collision.CompareTag("PlayerTom")) //check for player touch
        {
            sr.enabled = true;
            text.enabled = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAmy") || collision.CompareTag("PlayerTom")) //check for player touch
        {
            sr.enabled= false;
            text.enabled = false;
        }
    }
}
