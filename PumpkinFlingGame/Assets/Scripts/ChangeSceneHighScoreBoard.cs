using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneHighScoreBoard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTom") || other.CompareTag("PlayerAmy"))
        {
            SceneManager.LoadScene("HighScoreBoard");
        }
    }
}
