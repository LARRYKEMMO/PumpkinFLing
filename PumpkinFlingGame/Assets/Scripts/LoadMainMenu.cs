using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : FadeOut
{
    void Awake()
    {
        //StartCoroutine(loadMainMenuScreen());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator loadMainMenuScreen()
    {
        yield return new WaitForSeconds(10);
        StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");
    }
}
