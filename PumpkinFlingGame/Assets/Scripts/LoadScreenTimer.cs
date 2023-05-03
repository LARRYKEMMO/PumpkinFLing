using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenTimer : FadeOut
{
    
    void Awake()
    {
        StartCoroutine(loadCompanyLogoScreen());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator loadCompanyLogoScreen()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("PumpkinFlingLogo");
        
       
    }
    
}
