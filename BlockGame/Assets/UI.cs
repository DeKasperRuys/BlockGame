using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject btnRed, btnGreen, btnBlue, btnOrange, btnPurple, btnYellow, btnCyan;
    public TextMeshProUGUI clickCounterText, timerText;
    public bool isFinished = false;
    public int clickCounter = 0;
    public float timer = 0.0f;
    public GameObject gameUI, chooseColorUI;
    [SerializeField] public Button btnReplay;
    [SerializeField] Replay replay;
    [SerializeField] GameManager gameLogic;

    private bool hasStarted => gameLogic.hasStarted == true;

    private void Start()
    {
        gameUI.SetActive(false);
        chooseColorUI.SetActive(true);


    }

    private void Update()
    {
        clickCounterText.text = "Turns: " + clickCounter.ToString();

    


        if (isFinished == false && hasStarted)
        {
            positionColouredPlayButtons();
            hideRestartButton();
            showGame();
            showTimer();
        }
        else
        {
            showRestartButton();
        }

        if (replay.isRestarting ==true)
        {
            hideRestartButton();
        }
    }

    private void showTimer()
    {
        timer += Time.deltaTime;
        int seconds = (int)timer % 60;
        timerText.text = "Time: " + seconds;
    }

    private void showGame()
    {
        //Hide choose colour UI
        gameUI.SetActive(true);
        chooseColorUI.SetActive(false);
    }

    public void showRestartButton()
    {
        btnReplay.gameObject.SetActive(true);
    }

    public void hideRestartButton()
    {
        btnReplay.gameObject.SetActive(false);
    }

    public void positionColouredPlayButtons()
    {
        switch (ChooseColour.chosenColourCode)
        {
            case 0:
                btnCyan.SetActive(true);
                btnCyan.GetComponent<RectTransform>().localPosition = btnRed.GetComponent<RectTransform>().localPosition;
                btnRed.SetActive(false);
                break;
            case 1:
                btnCyan.SetActive(true);
                btnCyan.GetComponent<RectTransform>().localPosition = btnGreen.GetComponent<RectTransform>().localPosition;
                btnGreen.SetActive(false);
                break;
            case 2:
                btnCyan.SetActive(true);
                btnCyan.GetComponent<RectTransform>().localPosition = btnBlue.GetComponent<RectTransform>().localPosition;
                btnBlue.SetActive(false);
                break;
            case 3:
                btnCyan.SetActive(true);
                btnCyan.GetComponent<RectTransform>().localPosition = btnOrange.GetComponent<RectTransform>().localPosition;
                btnOrange.SetActive(false);
                break;
            case 4:
                btnCyan.SetActive(true);
                btnCyan.GetComponent<RectTransform>().localPosition = btnPurple.GetComponent<RectTransform>().localPosition;
                btnPurple.SetActive(false);
                break;
            case 5:
                btnCyan.SetActive(true);
                btnCyan.GetComponent<RectTransform>().localPosition = btnYellow.GetComponent<RectTransform>().localPosition;
                btnYellow.SetActive(false);
                break;
        }
    }

    public void clickedRed()
    {
        addClickCount();
        gameLogic.addFriends(0);
        
    }
    public void clickedGreen()
    {
        addClickCount();
        gameLogic.addFriends(1);
    }
    public void clickedBlue()
    {
        addClickCount();
        gameLogic.addFriends(2);
    }
    public void clickedOrange()
    {
        addClickCount();
        gameLogic.addFriends(3);
    }
    public void clickedPurple()
    {
        addClickCount();
        gameLogic.addFriends(4);
    }
    public void clickedYellow()
    {
        addClickCount();
        gameLogic.addFriends(5);
    }
    public void clickedCyan()
    {
        addClickCount();
        gameLogic.addFriends(6);
        
    }

    private void addClickCount()
    {
        clickCounter++;
    }
}
