using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonTrigger : MonoBehaviour
{
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu"); // EditorSceneManager.OpenScene()
                                                // SceneManager.LoadScene("MainMenu");
                                                // SceneManager.UnloadSceneAsync("TestMap");

        }
    }
}
