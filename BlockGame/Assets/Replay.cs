using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    [SerializeField] public bool isRestarting = false;
    //[SerializeField] public Button btnReplay;
    [SerializeField] private BuildLevel buildLevel;
    [SerializeField] private GameManager gameManager;
    public void RestartGame()
    {
        isRestarting = true;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        gameManager.startGame();
        //buildLevel.GenerateGrid();
        isRestarting = false;
        //btnReplay.gameObject.SetActive(true);
    }


}
