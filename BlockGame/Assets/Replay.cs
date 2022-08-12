using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("game");
    }
}
