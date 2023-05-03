using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioChange : MonoBehaviour
{
    public AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void stopMusic()
    {
        _audioSource.Stop();
    }
}
