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
        
    }

    public void ChoseColourRed()
    {
        chosenColourCode = 0;
        chosenColour = StaticData.Red;
        gameLogic.startGame(GameManager.selectedLevel);
    }
    public void ChoseColourOrange()
    {
        chosenColourCode = 3; 
        chosenColour = StaticData.Orange; 
        gameLogic.startGame(GameManager.selectedLevel);
    }

    public void ChoseColourGreen()
    {
        chosenColourCode = 1; 
        chosenColour = StaticData.Green; 
        gameLogic.startGame(GameManager.selectedLevel);
    }

    public void ChoseColourBlue()
    {

        chosenColourCode = 2;
        chosenColour = StaticData.Blue;
        gameLogic.startGame(GameManager.selectedLevel);
    }

    public void ChoseColourCyan()
    {
        chosenColourCode = 6;
        chosenColour = StaticData.Cyan;
        gameLogic.startGame(GameManager.selectedLevel);
    }

    public void ChoseColourPurple()
    {
        chosenColourCode = 4;
        chosenColour = StaticData.Purple;
        gameLogic.startGame(GameManager.selectedLevel);
    }

    public void ChoseColourYellow()
    {
        chosenColourCode = 5;
        chosenColour = StaticData.Yellow;
        gameLogic.startGame(GameManager.selectedLevel);
    }
 

}
