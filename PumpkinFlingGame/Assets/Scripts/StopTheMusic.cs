using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTheMusic : MonoBehaviour
{
    DontDestroyMusic stopIt;
   // public AudioSource _audioSource;


    // Start is called before the first frame update
    void Awake()
    {
        stopIt._audioSource.Stop();
    }

   
    // Update is called once per frame
    void Update()
    {

    }
}
