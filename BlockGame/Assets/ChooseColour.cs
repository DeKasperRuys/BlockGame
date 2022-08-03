using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseColour : MonoBehaviour
{
    [SerializeField] private GameManager gameLogic;
    [SerializeField] public static Color chosenColour;
    [SerializeField] public static int chosenColourCode;


    private void Update()
    {
        Debug.Log("in choosecolour scipt is het : " + chosenColourCode);
    }

    public void ChoseColourRed()
    {
        chosenColourCode = 0;
        chosenColour = StaticData.Red;
        gameLogic.startGame();
    }
    public void ChoseColourOrange()
    {
        chosenColourCode = 3; 
        chosenColour = StaticData.Orange; 
        gameLogic.startGame();
    }

    public void ChoseColourGreen()
    {
        chosenColourCode = 1; 
        chosenColour = StaticData.Green; 
        gameLogic.startGame();
    }

    public void ChoseColourBlue()
    {

        chosenColourCode = 2;
        chosenColour = StaticData.Blue;
        gameLogic.startGame();
    }

    public void ChoseColourCyan()
    {
        chosenColourCode = 6;
        chosenColour = StaticData.Cyan;
        gameLogic.startGame();
    }

    public void ChoseColourPurple()
    {
        chosenColourCode = 4;
        chosenColour = StaticData.Purple;
        gameLogic.startGame();
    }

    public void ChoseColourYellow()
    {
        chosenColourCode = 5;
        chosenColour = StaticData.Yellow;
        gameLogic.startGame();
    }

    

}
