using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuNavigation : MonoBehaviour
{
    public GameObject menuUI, levelSelectUI, optionsUI, btnBack;
    // Start is called before the first frame update

    void Start()
    {
        menuUI.SetActive(true);
        levelSelectUI.SetActive(false);
        optionsUI.SetActive(false);
        btnBack.SetActive(false);
    }

    public void startGame()
    {
        SceneManager.LoadScene("game");
    }

    public void showMainMenu()
    {
        menuUI.SetActive(true);
        levelSelectUI.SetActive(false);
        optionsUI.SetActive(false);
        btnBack.SetActive(false);
    }
    public void showLevelSelect()
    {
        menuUI.SetActive(false);
        levelSelectUI.SetActive(true);
        optionsUI.SetActive(false);
        btnBack.SetActive(true);
    }
    public void showOptions()
    {
        menuUI.SetActive(false);
        levelSelectUI.SetActive(false);
        optionsUI.SetActive(true);
        btnBack.SetActive(true);


    }



}
