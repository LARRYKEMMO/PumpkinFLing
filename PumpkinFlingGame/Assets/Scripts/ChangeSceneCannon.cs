using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneCannon : MonoBehaviour
{    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerAmy") || other.CompareTag("PlayerTom")) //check for player touch
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("PumpkinFlingGame"); //load the specified scene
    }
}
