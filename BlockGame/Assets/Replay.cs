using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    [SerializeField] public UI ui;
    //[SerializeField] public Button btnReplay;
    [SerializeField] private BuildLevel buildLevel;
    [SerializeField] private GameManager gameManager;
    public void RestartGame()
    {


        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        SceneManager.LoadScene("game");



    }


}
