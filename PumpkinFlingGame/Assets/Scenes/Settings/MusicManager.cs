using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public DontDestroyMusic _dontDestroyMusic;
    private AudioSource _audioSource;
    private float musicVolume = 1f;
    private float maxVolume = 1f;
    public static bool isPlaying = false;
    public static bool stopAudioCheck = false;

    // Start is called before the first frame update
    void Awake()
    {
        _dontDestroyMusic = GameObject.Find("Main Camera").GetComponent<DontDestroyMusic>();
        _audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {       
        if (musicVolume > maxVolume)
        {
            musicVolume = maxVolume;        
        }
        _dontDestroyMusic._audioSource.volume = musicVolume;

       
    }
    public void updateVolume(float Volume)
    {       
        musicVolume = Volume;
    }
    public void updateMasterVolume(float Volume)
    {
        maxVolume = Volume;
        musicVolume = Volume;
       
    }
    
    public void setAudioBoolTrue()
    {
        MusicManager.isPlaying = true;
    }

}
