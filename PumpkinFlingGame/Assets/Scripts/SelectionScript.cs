using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScript : MonoBehaviour
{
    public GameObject Tom;
    public GameObject Amy;
    public GameObject boom1;
    public GameObject boom2;
    private Animator anim;
    private Animator anim2;
    private int ButtonCounter;
    // Start is called before the first frame update
    void Start()
    {
        anim = Tom.GetComponent<Animator>();
        anim2 = Amy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseTom()
    {
    //    Debug.Log("Tom");
        if (ButtonCounter < 1)
        {
            boom1.SetActive(true);
            anim2.SetBool("IsSad", true);
            ButtonCounter++;
            MainManager.chooseTom = true;
            MainManager.chooseAmy = false;
            Invoke("LoadScene", 5);
            //    SceneManager.LoadScene("MainScreen");
        }
    }

    public void ChooseAmy()
    {
    //    Debug.Log("Tom");
        
        if(ButtonCounter < 1)
        {
            boom2.SetActive(true);
            anim.SetBool("IsSad", true);
            ButtonCounter++;
            MainManager.chooseTom = false;
            MainManager.chooseAmy = true;
            Invoke("LoadScene", 5);
        }
    }

    
    public void LoadScene()
    {
        SceneManager.LoadScene(5);
    }
    
}
