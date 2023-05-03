using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCharacters : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject playerAmy;
    private GameObject playerTom;
    private GameObject sideAmy;
    private GameObject sideTom;
    void Start()
    {
        sideTom = GameObject.FindWithTag("TomPrefab");
        playerTom = GameObject.FindWithTag("PlayerTom");
        sideAmy = GameObject.FindWithTag("AmyPrefab");
        playerAmy = GameObject.FindWithTag("PlayerAmy");
        if (MainManager.chooseTom == true)
        {
            playerAmy.SetActive(false);
            sideTom.SetActive(false);
          
        }
        if (MainManager.chooseAmy == true)
        {
            playerTom.SetActive(false);
            sideAmy.SetActive(false);
            
        }
    }

 
}
