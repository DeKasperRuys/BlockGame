using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //int[,] StaticData.level0;
    

    public int x = 0;
    public int y = 0;


    List<(int X, int Y)> friends = new List<(int X, int Y)>();
    List<(int X, int Y)> tempfriends = new List<(int X, int Y)>();

    [SerializeField] private UI ui;
    [SerializeField] private BuildLevel buildLevel;
    [SerializeField] private CheckLevelComplete checkLevelComplete;
    float timer;
    public bool hasStarted = false;


    public void startGame()
    {
        hasStarted = true;
        friends.Add((0, 0));
        buildLevel.GenerateGrid();

    }

    public void addFriends(int number)
    {


        int xCounter = 0;
        tempfriends.Clear();

        bool checkedX = false;
        bool checkedY = false;

        int iCHeckedthismanytimes = 0;
        /*foreach (var friend in friends)
            {
        */




        //THERE WAS AN ATTEMPT VOOR DIE IFS LEESBAARDER TE MAKEN MAAR FAK IT
        //DIE COMPLAINED HEEL DE TIJD OVER OUT OF BOUNDS
        /*
        var isRightSameColour = StaticData.level0[friends[xCounter].X + 1, friends[xCounter].Y] == number && friends[xCounter].X + 1 < StaticData.level0.GetLength(0);
        var isLeftSameColour = StaticData.level0[friends[xCounter].X - 1, friends[xCounter].Y] == number && friends[xCounter].X > 0;
        var isUnderSameColour = StaticData.level0[friends[xCounter].X, friends[xCounter].Y + 1] == number&& friends[xCounter].Y + 1 < StaticData.level0.GetLength(1);
        var isAboveSameColour = StaticData.level0[friends[xCounter].X, friends[xCounter].Y - 1] == number && friends[xCounter].Y > 0 ;
        */
        for (int i = 0; i < friends.Count(); i++)
        {
            int numberFriends = friends.Count(t => t.X >= 0);

            // Debug.Log("xCounter is " + xCounter);
            //Debug.Log("changing StaticData.level0 position: "+ friends[xCounter].X + "" + friends[xCounter].Y + " To number " + number + "after checking if it is a friend");
            StaticData.level0[friends[xCounter].X, friends[xCounter].Y] = number;


            // IS RIGHT NEIGHBOUR THE SAME ??
            if (friends[xCounter].X + 1 < StaticData.level0.GetLength(0) && StaticData.level0[friends[xCounter].X + 1, friends[xCounter].Y] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {

                tempfriends.Add((friends[xCounter].X + 1, friends[xCounter].Y));
                StaticData.needsCheckingLevel0[friends[xCounter].X + 1, friends[xCounter].Y] = true;
                checkedX = true;
                iCHeckedthismanytimes++;
            }
            // IS UNDER NEIGHBOUR THE SAME ??
            if (friends[xCounter].Y + 1 < StaticData.level0.GetLength(1) && StaticData.level0[friends[xCounter].X, friends[xCounter].Y + 1] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                //Debug.Log("bottom neighbour of " + friends[xCounter].X + "," + friends[xCounter].Y + " is the same number so adding to friends");
                tempfriends.Add((friends[xCounter].X, friends[xCounter].Y + 1));
                StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y + 1] = true;
                checkedY = true;
                iCHeckedthismanytimes++;
            }
            // IS LEFT NEIGHBOUR THE SAME ??
            if (friends[xCounter].X > 0 && StaticData.level0[friends[xCounter].X - 1, friends[xCounter].Y] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                tempfriends.Add((friends[xCounter].X - 1, friends[xCounter].Y));
                StaticData.needsCheckingLevel0[friends[xCounter].X - 1, friends[xCounter].Y] = true;
                iCHeckedthismanytimes++;
            }
            // IS UP NEIGHBOUR THE SAME ??
            if (friends[xCounter].Y > 0 && StaticData.level0[friends[xCounter].X, friends[xCounter].Y - 1] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                tempfriends.Add((friends[xCounter].X, friends[xCounter].Y - 1));
                StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y - 1] = true;
                iCHeckedthismanytimes++;
            }
            friends.AddRange(tempfriends.Distinct());
            friends = friends.Distinct().ToList();


            //change colours of friends
            GameObject theBlock = GameObject.Find("Tile" + friends[xCounter].X + "" + friends[xCounter].Y);
            theBlock.GetComponent<SpriteRenderer>().color = ChooseColour.chosenColour;



            if (checkedX == true && checkedY == true)
            {
                StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] = false;

            }


            checkedX = false;
            checkedY = false;

            xCounter++;
            

            // 

            Debug.Log(tempfriends);
        }
        xCounter = 0;

        if (checkLevelComplete.Checker(StaticData.level0, number) == true)
        {
            ui.isFinished = true;
        }


    }



}

