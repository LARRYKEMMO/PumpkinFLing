using Assets.HeroEditor.Common.Scripts.CharacterScripts;
using JetBrains.Annotations;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToShop : MonoBehaviour
{

    
    public AIDestinationSetter a;
    public Character motion;
    private GameObject playerAmy;
    private GameObject playerTom;
    private GameObject sideAmy;
    private GameObject sideTom;
    private void Start()
    {
        sideTom = GameObject.FindWithTag("TomPrefab");
        playerTom = GameObject.FindWithTag("PlayerTom");
        sideAmy = GameObject.FindWithTag("AmyPrefab");
        playerAmy = GameObject.FindWithTag("PlayerAmy");
        if (MainManager.chooseTom == true)
        {
            playerAmy.SetActive(false);
            sideTom.SetActive(false);
            a = playerTom.GetComponent<AIDestinationSetter>();
            motion = playerTom.GetComponent<Character>();
        }
        if (MainManager.chooseAmy == true)
        {
            playerTom.SetActive(false);
            sideAmy.SetActive(false);
            a = playerAmy.GetComponent<AIDestinationSetter>();
            motion = playerAmy.GetComponent<Character>();
        }
    }
    public void goToShop()
    {
        motion.SetState(CharacterState.Walk);
        a.target = GameObject.Find("Shop").transform; 
    }
    public void goToCannon()
    {
        motion.SetState(CharacterState.Walk);
        a.target = GameObject.Find("Cannon").transform;
    }
    public void goToPlinko()
    {
        motion.SetState(CharacterState.Walk);
        a.target = GameObject.Find("Plinko").transform;
    }
    public void goToRaces()
    {
        motion.SetState(CharacterState.Walk);
        a.target = GameObject.Find("Races").transform;
    }
    public void HighScoreBoard()
    {
        motion.SetState(CharacterState.Walk);
        a.target = GameObject.Find("HighScoreBoard").transform;
    }
}
