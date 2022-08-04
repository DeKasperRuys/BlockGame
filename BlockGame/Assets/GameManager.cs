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
    public int[,] copyOfLevel = new int[10, 10];

    public void startGame()
    {
        copyOfLevel = StaticData.level0;
        hasStarted = true;

        CallArray();
        friends.Clear();
        tempfriends.Clear();
        friends.Add((0, 0));
        buildLevel.GenerateGrid(copyOfLevel);
        CallArray();
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
        var isRightSameColour = copyOfLevel[friends[xCounter].X + 1, friends[xCounter].Y] == number && friends[xCounter].X + 1 < copyOfLevel.GetLength(0);
        var isLeftSameColour = copyOfLevel[friends[xCounter].X - 1, friends[xCounter].Y] == number && friends[xCounter].X > 0;
        var isUnderSameColour = copyOfLevel[friends[xCounter].X, friends[xCounter].Y + 1] == number&& friends[xCounter].Y + 1 < copyOfLevel.GetLength(1);
        var isAboveSameColour = copyOfLevel[friends[xCounter].X, friends[xCounter].Y - 1] == number && friends[xCounter].Y > 0 ;
        */
        for (int i = 0; i < friends.Count(); i++)
        {
            int numberFriends = friends.Count(t => t.X >= 0);

            // Debug.Log("xCounter is " + xCounter);
            //Debug.Log("changing copyOfLevel position: "+ friends[xCounter].X + "" + friends[xCounter].Y + " To number " + number + "after checking if it is a friend");
            copyOfLevel[friends[xCounter].X, friends[xCounter].Y] = number;


            // IS RIGHT NEIGHBOUR THE SAME ??
            if (friends[xCounter].X + 1 < copyOfLevel.GetLength(0) && copyOfLevel[friends[xCounter].X + 1, friends[xCounter].Y] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {

                tempfriends.Add((friends[xCounter].X + 1, friends[xCounter].Y));
                StaticData.needsCheckingLevel0[friends[xCounter].X + 1, friends[xCounter].Y] = true;
                checkedX = true;
                iCHeckedthismanytimes++;
            }
            // IS UNDER NEIGHBOUR THE SAME ??
            if (friends[xCounter].Y + 1 < copyOfLevel.GetLength(1) && copyOfLevel[friends[xCounter].X, friends[xCounter].Y + 1] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                //Debug.Log("bottom neighbour of " + friends[xCounter].X + "," + friends[xCounter].Y + " is the same number so adding to friends");
                tempfriends.Add((friends[xCounter].X, friends[xCounter].Y + 1));
                StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y + 1] = true;
                checkedY = true;
                iCHeckedthismanytimes++;
            }
            // IS LEFT NEIGHBOUR THE SAME ??
            if (friends[xCounter].X > 0 && copyOfLevel[friends[xCounter].X - 1, friends[xCounter].Y] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                tempfriends.Add((friends[xCounter].X - 1, friends[xCounter].Y));
                StaticData.needsCheckingLevel0[friends[xCounter].X - 1, friends[xCounter].Y] = true;
                iCHeckedthismanytimes++;
            }
            // IS UP NEIGHBOUR THE SAME ??
            if (friends[xCounter].Y > 0 && copyOfLevel[friends[xCounter].X, friends[xCounter].Y - 1] == number && StaticData.needsCheckingLevel0[friends[xCounter].X, friends[xCounter].Y] == true)
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

        if (checkLevelComplete.Checker(copyOfLevel, number) == true)
        {
            ui.isFinished = true;
        }


    }



    public void CallArray()
    {
        Debug.Log("[" + copyOfLevel[0, 0] + "," + copyOfLevel[0, 1] + "," + copyOfLevel[0, 2] + "," + copyOfLevel[0, 3] + "," + copyOfLevel[0, 4] + "," + copyOfLevel[0, 5] + "," + copyOfLevel[0, 6] + "," + copyOfLevel[0, 7] + "," + copyOfLevel[0, 8] + "," + copyOfLevel[0, 9] + "]\n" +
            "[" + copyOfLevel[1, 0] + "," + copyOfLevel[1, 1] + "," + copyOfLevel[1, 2] + "," + copyOfLevel[1, 3] + "," + copyOfLevel[1, 4] + "," + copyOfLevel[1, 5] + "," + copyOfLevel[1, 6] + "," + copyOfLevel[1, 7] + "," + copyOfLevel[1, 8] + "," + copyOfLevel[1, 9] + "]\n" +
            "[" + copyOfLevel[2, 0] + "," + copyOfLevel[2, 1] + "," + copyOfLevel[2, 2] + "," + copyOfLevel[2, 3] + "," + copyOfLevel[2, 4] + "," + copyOfLevel[2, 5] + "," + copyOfLevel[2, 6] + "," + copyOfLevel[2, 7] + "," + copyOfLevel[2, 8] + "," + copyOfLevel[2, 9] + "]\n" +
             "[" + copyOfLevel[3, 0] + "," + copyOfLevel[3, 1] + "," + copyOfLevel[3, 2] + "," + copyOfLevel[3, 3] + "," + copyOfLevel[3, 4] + "," + copyOfLevel[3, 5] + "," + copyOfLevel[3, 6] + "," + copyOfLevel[3, 7] + "," + copyOfLevel[3, 8] + "," + copyOfLevel[3, 9] + "]\n" +
             "[" + copyOfLevel[4, 0] + "," + copyOfLevel[4, 1] + "," + copyOfLevel[4, 2] + "," + copyOfLevel[4, 3] + "," + copyOfLevel[4, 4] + "," + copyOfLevel[4, 5] + "," + copyOfLevel[4, 6] + "," + copyOfLevel[4, 7] + "," + copyOfLevel[4, 8] + "," + copyOfLevel[4, 9] + "]\n" +
             "[" + copyOfLevel[5, 0] + "," + copyOfLevel[5, 1] + "," + copyOfLevel[5, 2] + "," + copyOfLevel[5, 3] + "," + copyOfLevel[5, 4] + "," + copyOfLevel[5, 5] + "," + copyOfLevel[5, 6] + "," + copyOfLevel[5, 7] + "," + copyOfLevel[5, 8] + "," + copyOfLevel[5, 9] + "]\n" +
             "[" + copyOfLevel[6, 0] + "," + copyOfLevel[6, 1] + "," + copyOfLevel[6, 2] + "," + copyOfLevel[6, 3] + "," + copyOfLevel[6, 4] + "," + copyOfLevel[6, 5] + "," + copyOfLevel[6, 6] + "," + copyOfLevel[6, 7] + "," + copyOfLevel[6, 8] + "," + copyOfLevel[6, 9] + "]\n" +
             "[" + copyOfLevel[7, 0] + "," + copyOfLevel[7, 1] + "," + copyOfLevel[7, 2] + "," + copyOfLevel[7, 3] + "," + copyOfLevel[7, 4] + "," + copyOfLevel[7, 5] + "," + copyOfLevel[7, 6] + "," + copyOfLevel[7, 7] + "," + copyOfLevel[7, 8] + "," + copyOfLevel[7, 9] + "]\n" +
             "[" + copyOfLevel[8, 0] + "," + copyOfLevel[8, 1] + "," + copyOfLevel[8, 2] + "," + copyOfLevel[8, 3] + "," + copyOfLevel[8, 4] + "," + copyOfLevel[8, 5] + "," + copyOfLevel[8, 6] + "," + copyOfLevel[8, 7] + "," + copyOfLevel[8, 8] + "," + copyOfLevel[8, 9] + "]\n" +
             "[" + copyOfLevel[9, 0] + "," + copyOfLevel[9, 1] + "," + copyOfLevel[9, 2] + "," + copyOfLevel[9, 3] + "," + copyOfLevel[9, 4] + "," + copyOfLevel[9, 5] + "," + copyOfLevel[9, 6] + "," + copyOfLevel[9, 7] + "," + copyOfLevel[9, 8] + "," + copyOfLevel[9, 9] + "]\n");


        Debug.Log("[" + StaticData.needsCheckingLevel0[0, 0] + "," + StaticData.needsCheckingLevel0[0, 1] + "," + StaticData.needsCheckingLevel0[0, 2] + "," + StaticData.needsCheckingLevel0[0, 3] + "," + StaticData.needsCheckingLevel0[0, 4] + "," + StaticData.needsCheckingLevel0[0, 5] + "," + StaticData.needsCheckingLevel0[0, 6] + "," + StaticData.needsCheckingLevel0[0, 7] + "," + StaticData.needsCheckingLevel0[0, 8] + "," + StaticData.needsCheckingLevel0[0, 9] + "]\n" +
            "[" + StaticData.needsCheckingLevel0[1, 0] + "," + StaticData.needsCheckingLevel0[1, 1] + "," + StaticData.needsCheckingLevel0[1, 2] + "," + StaticData.needsCheckingLevel0[1, 3] + "," + StaticData.needsCheckingLevel0[1, 4] + "," + StaticData.needsCheckingLevel0[1, 5] + "," + StaticData.needsCheckingLevel0[1, 6] + "," + StaticData.needsCheckingLevel0[1, 7] + "," + StaticData.needsCheckingLevel0[1, 8] + "," + StaticData.needsCheckingLevel0[1, 9] + "]\n" +
            "[" + StaticData.needsCheckingLevel0[2, 0] + "," + StaticData.needsCheckingLevel0[2, 1] + "," + StaticData.needsCheckingLevel0[2, 2] + "," + StaticData.needsCheckingLevel0[2, 3] + "," + StaticData.needsCheckingLevel0[2, 4] + "," + StaticData.needsCheckingLevel0[2, 5] + "," + StaticData.needsCheckingLevel0[2, 6] + "," + StaticData.needsCheckingLevel0[2, 7] + "," + StaticData.needsCheckingLevel0[2, 8] + "," + StaticData.needsCheckingLevel0[2, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[3, 0] + "," + StaticData.needsCheckingLevel0[3, 1] + "," + StaticData.needsCheckingLevel0[3, 2] + "," + StaticData.needsCheckingLevel0[3, 3] + "," + StaticData.needsCheckingLevel0[3, 4] + "," + StaticData.needsCheckingLevel0[3, 5] + "," + StaticData.needsCheckingLevel0[3, 6] + "," + StaticData.needsCheckingLevel0[3, 7] + "," + StaticData.needsCheckingLevel0[3, 8] + "," + StaticData.needsCheckingLevel0[3, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[4, 0] + "," + StaticData.needsCheckingLevel0[4, 1] + "," + StaticData.needsCheckingLevel0[4, 2] + "," + StaticData.needsCheckingLevel0[4, 3] + "," + StaticData.needsCheckingLevel0[4, 4] + "," + StaticData.needsCheckingLevel0[4, 5] + "," + StaticData.needsCheckingLevel0[4, 6] + "," + StaticData.needsCheckingLevel0[4, 7] + "," + StaticData.needsCheckingLevel0[4, 8] + "," + StaticData.needsCheckingLevel0[4, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[5, 0] + "," + StaticData.needsCheckingLevel0[5, 1] + "," + StaticData.needsCheckingLevel0[5, 2] + "," + StaticData.needsCheckingLevel0[5, 3] + "," + StaticData.needsCheckingLevel0[5, 4] + "," + StaticData.needsCheckingLevel0[5, 5] + "," + StaticData.needsCheckingLevel0[5, 6] + "," + StaticData.needsCheckingLevel0[5, 7] + "," + StaticData.needsCheckingLevel0[5, 8] + "," + StaticData.needsCheckingLevel0[5, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[6, 0] + "," + StaticData.needsCheckingLevel0[6, 1] + "," + StaticData.needsCheckingLevel0[6, 2] + "," + StaticData.needsCheckingLevel0[6, 3] + "," + StaticData.needsCheckingLevel0[6, 4] + "," + StaticData.needsCheckingLevel0[6, 5] + "," + StaticData.needsCheckingLevel0[6, 6] + "," + StaticData.needsCheckingLevel0[6, 7] + "," + StaticData.needsCheckingLevel0[6, 8] + "," + StaticData.needsCheckingLevel0[6, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[7, 0] + "," + StaticData.needsCheckingLevel0[7, 1] + "," + StaticData.needsCheckingLevel0[7, 2] + "," + StaticData.needsCheckingLevel0[7, 3] + "," + StaticData.needsCheckingLevel0[7, 4] + "," + StaticData.needsCheckingLevel0[7, 5] + "," + StaticData.needsCheckingLevel0[7, 6] + "," + StaticData.needsCheckingLevel0[7, 7] + "," + StaticData.needsCheckingLevel0[7, 8] + "," + StaticData.needsCheckingLevel0[7, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[8, 0] + "," + StaticData.needsCheckingLevel0[8, 1] + "," + StaticData.needsCheckingLevel0[8, 2] + "," + StaticData.needsCheckingLevel0[8, 3] + "," + StaticData.needsCheckingLevel0[8, 4] + "," + StaticData.needsCheckingLevel0[8, 5] + "," + StaticData.needsCheckingLevel0[8, 6] + "," + StaticData.needsCheckingLevel0[8, 7] + "," + StaticData.needsCheckingLevel0[8, 8] + "," + StaticData.needsCheckingLevel0[8, 9] + "]\n" +
             "[" + StaticData.needsCheckingLevel0[9, 0] + "," + StaticData.needsCheckingLevel0[9, 1] + "," + StaticData.needsCheckingLevel0[9, 2] + "," + StaticData.needsCheckingLevel0[9, 3] + "," + StaticData.needsCheckingLevel0[9, 4] + "," + StaticData.needsCheckingLevel0[9, 5] + "," + StaticData.needsCheckingLevel0[9, 6] + "," + StaticData.needsCheckingLevel0[9, 7] + "," + StaticData.needsCheckingLevel0[9, 8] + "," + StaticData.needsCheckingLevel0[9, 9] + "]\n");
    }



}

