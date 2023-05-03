using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundCheck : MonoBehaviour
{
    public AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (MusicManager.isPlaying == true)
        {
            DontDestroyOnLoad(_audioSource);
            _audioSource.Play();
        }
    }
    private void Update()
    {
       
    }


}
