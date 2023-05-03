using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;



public class LoadScenesScript : MonoBehaviour
{
    SaveData sd = new SaveData();
    private DontDestroyMusic dontDestroyMusicScript;
    //MusicManager musicManager;
    //DontDestroyMusic stopMusic;
    private string EVENTTAG = "Event";

    public void Start()
    {
        
        dontDestroyMusicScript = FindObjectOfType<DontDestroyMusic>();
        //stopMusic = gameObject.AddComponent<DontDestroyMusic>();
    }

    public void HelpMethod()
    {
        SceneManager.LoadScene("HelpScreen");
    }

    public void mainMenubackMethod()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlayMethod()
    {
        SceneManager.LoadScene("howToPlay");
    }

    public void HowToUseMapMethod()
    {
        SceneManager.LoadScene("HowToUseMap");
    }

    public void HowToUseHighscoreMethod()
    {
        SceneManager.LoadScene("howToUseHighScore");
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings");

    }

    public void LoadAudio()
    {
        SceneManager.LoadScene("Audio");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PumpkinFlingLogo");
    }
    public void LoadScoreBoard()
    {
        SceneManager.LoadScene("HighScoreBoard");
    }
    public void goToMap()
    {

        if (System.IO.File.Exists(Application.persistentDataPath + "/highScoreData.json"))
        {
            //stopMusic._audioSource.Stop();
        //    SceneManager.LoadScene("MainScreen");
            MusicManager.stopAudioCheck = false;
        }
        else
        {
            sd.CreateJson();
            //stopMusic._audioSource.Stop();
        //    SceneManager.LoadScene("MainScreen");
            MusicManager.stopAudioCheck = false;
        }

        dontDestroyMusicScript.StopPotatoSound();
    }

    public void goToMap2()
    {

        if (System.IO.File.Exists(Application.persistentDataPath + "/highScoreData.json"))
        {
            //stopMusic._audioSource.Stop();
                SceneManager.LoadScene("MainScreen");
            MusicManager.stopAudioCheck = false;
        }
        else
        {
            sd.CreateJson();
            //stopMusic._audioSource.Stop();
                SceneManager.LoadScene("MainScreen");
            MusicManager.stopAudioCheck = false;
        }

        dontDestroyMusicScript.StopPotatoSound();
    }

    public void goToPumpkinFlingStage()
    {
        SceneManager.LoadScene("PumpkinFlingGame");

    }
    public void goToSelection()
    {
        SceneManager.LoadScene("SelectionScene");
    }

    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(EVENTTAG))
        {
            SceneManager.LoadScene("MainMenu"); // EditorSceneManager.OpenScene()
                                                // SceneManager.LoadScene("MainMenu");
                                                // SceneManager.UnloadSceneAsync("TestMap");

        }

    }
}
