using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    // bool stopAudioCheck = false;
    public AudioSource _audioSource;
    private bool StopPotato = false;
    private bool PotatoPlaying = true;
    //public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(_audioSource);

    }



    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "PumpkinFlingGame")
        {
            SetVolume();
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScreen") && MusicManager.stopAudioCheck == false)
        {

            _audioSource.Stop();
          //  Debug.Log("I STOPPED THE AUDIO");
          //  Debug.Log(MusicManager.stopAudioCheck);
            playNewMusic();

            //     _audioSource.Play();
        }

        if (StopPotato == true && PotatoPlaying == false)
        {
            _audioSource.Stop();
        }
    }
    public void playNewMusic()
    {
       // Debug.Log("I STARTED THE AUDIO");
        MusicManager.stopAudioCheck = true;
       // Debug.Log(MusicManager.stopAudioCheck);
        _audioSource.Play();
    }

    public void StopPotatoSound()
    {
        StopPotato = true;
        PotatoPlaying = false;
    }

    public void SetVolume()
    {
       // Debug.Log("Volume: " + _audioSource.volume);
        _audioSource.volume = 0.032f;
        //Debug.Log("Volume: " + _audioSource.volume);
    }
}
