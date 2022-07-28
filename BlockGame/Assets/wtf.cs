using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class wtf : MonoBehaviour
{
    int[,] arr2d;
    bool[,] needsChecking;
    List<(int X, int Y)> friends = new List<(int X, int Y)>();
    public int x = 0;
    public int y = 0;
    public GameObject gameUI, chooseColorUI;
    List<(int X, int Y)> tempfriends = new List<(int X, int Y)>();
    public Color chosenColour;
    public int chosenColourCode;
    public Color Red, Green, Blue, Orange, Cyan, Purple, Yellow;
    public GameObject btnRed, btnGreen, btnBlue, btnOrange, btnPurple, btnYellow, btnCyan;
    private int clickCounter;
    public TextMeshProUGUI clickCounterText, timerText;
    public Button btnReplay;

    float timer;


    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private Transform camera;

    public float divider = 1.795f;
    bool isFinished;
    // Start is called before the first frame update

    void Start()
    {
        gameUI.SetActive(false);
        chooseColorUI.SetActive(true);


        btnReplay.onClick.AddListener(() => RestartGame());

        //btnReplay.gameObject.SetActive(false);

        clickCounter = 0;
        timer = 0.0f;

        Red = new Color(0.8584f, 0.0283f, 0.0283f, 1);
        Green = new Color(0.0040f, 0.8584f, 0.0040f, 1);
        Blue = new Color(0.1856f, 0.1856f, 0.9150f, 1);
        Orange = new Color(1f, 0.5286f, 0.1745f, 1);
        Purple = new Color(0.7286f, 0.1752f, 0.9528f, 1);
        Yellow = new Color(1f, 1f, 0.0336f, 1);
        Cyan = new Color(0.1079f, 0.9150f, 0.9150f, 1);
        

        
        //startGame();
    }
    void startGame()
    {


        switch (chosenColourCode)
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

        gameUI.SetActive(true);
        chooseColorUI.SetActive(false);

        //create level

        arr2d = new int[10, 10]
        {
            {chosenColourCode,1,2,1,3,0,0,0,0,0},
                            {1,2,1,3,1,0,1,2,1,3 },
                            {2,1,3,1,4,4,4,2,1,3 },
                            {1,3,1,4,1,0,1,4,1,3 },
                            {2,1,3,1,4,0,4,2,1,3 },
                            {2,1,3,1,4,0,1,2,1,3 },
                            {2,1,5,1,4,0,1,5,1,3 },
                            {2,1,3,1,4,0,1,2,1,3 },
                            {2,1,3,1,4,0,1,5,1,3 },
                            {2,1,3,1,4,0,1,2,1,3 }
        };




        needsChecking = new bool[10, 10]
         {
            {true,false,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false },
            {false,false,false,false,false,false,false,false,false,false }
         };

        friends.Add((0, 0));

        CallArray();

        //Debug.Log("DIT IS 0 = "+arr2d.GetLength(0)); //0 is hoogte array
        //Debug.Log("DIT IS 1 = "+arr2d.GetLength(1)); //1 is  lengte array

        GenerateGrid();
    }

  
    void GenerateGrid()
    {
      

        for (int x = 0; x < arr2d.GetLength(0); x++)
        {
            for (int y = 0; y < arr2d.GetLength(1); y++)
            {

                if (x + y != 0)
                {
                    if (chosenColourCode != 6)
                    {
                        if (arr2d[x, y] == chosenColourCode)
                        {
                            arr2d[x, y] = 6;
                        }
                    }
                }




                var spawnedTile = Instantiate(tilePrefab, new Vector3(y / divider, -x / divider), transform.rotation);
                spawnedTile.name = $"Tile{x}{y}";

                // spawnedTile.tag = x + "" + y;
                spawnedTile.transform.parent = GameObject.Find("Grid").transform;
                if (arr2d[x, y] == 0)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Red;
                    //spawnedTile.Init(0, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (arr2d[x, y] == 1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Green;
                    //spawnedTile.Init(1,Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (arr2d[x, y] == 2)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Blue;
                    //spawnedTile.Init(2, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (arr2d[x, y] == 3)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Orange;
                    //spawnedTile.Init(3, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (arr2d[x, y] == 4)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Purple;
                    //spawnedTile.Init(4, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (arr2d[x, y] == 5)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Yellow;
                    //spawnedTile.Init(5, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (arr2d[x, y] == 6)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = Cyan;
                    //spawnedTile.Init(6, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
            }

        }
        Debug.Log(Time.realtimeSinceStartup - timer);  // 0.00389
        //camera.transform.position = new Vector3((float)arr2d.GetLength(1)/2 - 0.5f, (float)arr2d.GetLength(0) / 2 - 0.5f, -10);
    }

    void addFriends(int number)
    {
        clickCounter++;
        clickCounterText.text = "Turns: " + clickCounter.ToString();
        int xCounter = 0;
        int yCounter = 1;
        tempfriends.Clear();

        bool checkedX = false;
        bool checkedY = false;

        int iCHeckedthismanytimes = 0;
        /*foreach (var friend in friends)
            {
        */

        for (int i = 0; i < friends.Count(); i++)
        {
            int numberFriends = friends.Count(t => t.X >= 0);

            // Debug.Log("xCounter is " + xCounter);
            //Debug.Log("changing arr2d position: "+ friends[xCounter].X + "" + friends[xCounter].Y + " To number " + number + "after checking if it is a friend");
            arr2d[friends[xCounter].X, friends[xCounter].Y] = number;



            if (friends[xCounter].X + 1 < arr2d.GetLength(0) && arr2d[friends[xCounter].X + 1, friends[xCounter].Y] == number && needsChecking[friends[xCounter].X, friends[xCounter].Y] == true)
            {

                tempfriends.Add((friends[xCounter].X + 1, friends[xCounter].Y));
                needsChecking[friends[xCounter].X + 1, friends[xCounter].Y] = true;
                checkedX = true;
                iCHeckedthismanytimes++;
            }

            if (friends[xCounter].Y + 1 < arr2d.GetLength(1) && arr2d[friends[xCounter].X, friends[xCounter].Y + 1] == number && needsChecking[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                //Debug.Log("bottom neighbour of " + friends[xCounter].X + "," + friends[xCounter].Y + " is the same number so adding to friends");
                tempfriends.Add((friends[xCounter].X, friends[xCounter].Y + 1));
                needsChecking[friends[xCounter].X, friends[xCounter].Y + 1] = true;
                checkedY = true;
                iCHeckedthismanytimes++;
            }
            if (friends[xCounter].X > 0 && arr2d[friends[xCounter].X - 1, friends[xCounter].Y] == number && needsChecking[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                tempfriends.Add((friends[xCounter].X - 1, friends[xCounter].Y));
                needsChecking[friends[xCounter].X - 1, friends[xCounter].Y] = true;
                iCHeckedthismanytimes++;
            }
            if (friends[xCounter].Y > 0 && arr2d[friends[xCounter].X, friends[xCounter].Y - 1] == number && needsChecking[friends[xCounter].X, friends[xCounter].Y] == true)
            {
                tempfriends.Add((friends[xCounter].X, friends[xCounter].Y - 1));
                needsChecking[friends[xCounter].X, friends[xCounter].Y - 1] = true;
                iCHeckedthismanytimes++;
            }
            friends.AddRange(tempfriends.Distinct());
            friends = friends.Distinct().ToList();


            //change colours of friends
            GameObject theBlock = GameObject.Find("Tile" + friends[xCounter].X + "" + friends[xCounter].Y);
            theBlock.GetComponent<SpriteRenderer>().color = chosenColour;



            if (checkedX == true && checkedY == true)
            {
                needsChecking[friends[xCounter].X, friends[xCounter].Y] = false;

            }


            checkedX = false;
            checkedY = false;





            xCounter++;
            yCounter++;

            // 

            Debug.Log(tempfriends);
        }


        /*}*/
        //Debug.Log("Amount of friends before distinct = " + friends.Count());
        //friends.AddRange(tempfriends);

        //friends = friends.Distinct().ToList();
        //Debug.Log("Amount of friends after distinct = " + friends.Count());
        xCounter = 0;
        CallArray();









        //GenerateGrid();

        Debug.Log("this many times looped " + iCHeckedthismanytimes);
        //0 is hoogte array
        //1 is  lengte array
        if (Checker(arr2d, number) == true)
        {
            isFinished = true;
            btnReplay.gameObject.SetActive(true);
            Debug.Log("GAME IS FINISHED!!");
        }









    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        btnReplay.gameObject.SetActive(true);
    }
    public void replayButton()
    {
        RestartGame();
    }
    public void ChoseColourRed()
    {
        chosenColourCode = 0; chosenColour = Red; startGame();
    }
    public void ChoseColourOrange()
    {
        chosenColourCode = 3; chosenColour = Orange; startGame();
    }

    public void ChoseColourGreen()
    {
        chosenColourCode = 1; chosenColour = Green; startGame();
    }

    public void ChoseColourBlue()
    {
        chosenColourCode = 2; chosenColour = Blue; startGame();
    }

    public void ChoseColourCyan()
    {
        chosenColourCode = 6; chosenColour = Cyan; startGame();
    }

    public void ChoseColourPurple()
    {
        chosenColourCode = 4; chosenColour = Purple; startGame();
    }

    public void ChoseColourYellow()
    {
        chosenColourCode = 5; chosenColour = Yellow; startGame();
    }
    public void buttonRed()
    {
        addFriends(0);
    }
    public void buttonGreen()
    {
        addFriends(1);
    }
    public void buttonBlue()
    {
        addFriends(2);
    }
    public void buttonOrange()
    {
        addFriends(3);
    }
    public void buttonPurple()
    {
        addFriends(4);
    }
    public void buttonYellow()
    {
        addFriends(5);
    }
    public void buttonCyan()
    {
        addFriends(6);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFinished==false)
        {
            timer += Time.deltaTime;
            int seconds = (int)timer % 60;
            timerText.text = "Time: " + seconds;
        }
        else
        {
            RestartGame();
        }
        


    }



    /*
            {0,1,0,1,0},
            { 1,0,1,0,1 },
            { 0,1,0,1,0 },
            { 1,0,1,0,1 }
    */

    //0 is hoogte array
    //1 is  lengte array
    public bool Checker(int[,] array, int value)
    {
        for (int i = 0; i < arr2d.GetLength(1); i++)
        {
            for (int j = 0; j < arr2d.GetLength(0); j++)
            {
                //Debug.Log("Checking [" + j + "," + i+"]" + " and it is = " + arr2d[j,i] );
                if (arr2d[j, i] != value)
                {
                    return false;
                }

            }
        }
        return true;

    }
    /*
    public int WhatColour(GameObject block,  int number)
    {
        if (number == 0)
        {
            theBlock.GetComponent<Renderer>().material.color = Color.black
            return 0;
        }
        if (number == 1)
        {
            return  Color.green;
        }
        if (number == 2)
        {
            return  Color.blue;
        }
        if (number == 3)
        {
            return  Color.cyan;
        }
        if (number == 4)
        {
            return  Color.magenta;
        }
        if (number == 5)
        {
            return Color.yellow;
        }
    }*/

    public void CallArray()
    {
        Debug.Log("[" + arr2d[0, 0] + "," + arr2d[0, 1] + "," + arr2d[0, 2] + "," + arr2d[0, 3] + "," + arr2d[0, 4] + "," + arr2d[0, 5] + "," + arr2d[0, 6] + "," + arr2d[0, 7] + "," + arr2d[0, 8] + "," + arr2d[0, 9] + "]\n" +
            "[" + arr2d[1, 0] + "," + arr2d[1, 1] + "," + arr2d[1, 2] + "," + arr2d[1, 3] + "," + arr2d[1, 4] + "," + arr2d[1, 5] + "," + arr2d[1, 6] + "," + arr2d[1, 7] + "," + arr2d[1, 8] + "," + arr2d[1, 9] + "]\n" +
            "[" + arr2d[2, 0] + "," + arr2d[2, 1] + "," + arr2d[2, 2] + "," + arr2d[2, 3] + "," + arr2d[2, 4] + "," + arr2d[2, 5] + "," + arr2d[2, 6] + "," + arr2d[2, 7] + "," + arr2d[2, 8] + "," + arr2d[2, 9] + "]\n" +
             "[" + arr2d[3, 0] + "," + arr2d[3, 1] + "," + arr2d[3, 2] + "," + arr2d[3, 3] + "," + arr2d[3, 4] + "," + arr2d[3, 5] + "," + arr2d[3, 6] + "," + arr2d[3, 7] + "," + arr2d[3, 8] + "," + arr2d[3, 9] + "]\n" +
             "[" + arr2d[4, 0] + "," + arr2d[4, 1] + "," + arr2d[4, 2] + "," + arr2d[4, 3] + "," + arr2d[4, 4] + "," + arr2d[4, 5] + "," + arr2d[4, 6] + "," + arr2d[4, 7] + "," + arr2d[4, 8] + "," + arr2d[4, 9] + "]\n" +
             "[" + arr2d[5, 0] + "," + arr2d[5, 1] + "," + arr2d[5, 2] + "," + arr2d[5, 3] + "," + arr2d[5, 4] + "," + arr2d[5, 5] + "," + arr2d[5, 6] + "," + arr2d[5, 7] + "," + arr2d[5, 8] + "," + arr2d[5, 9] + "]\n" +
             "[" + arr2d[6, 0] + "," + arr2d[6, 1] + "," + arr2d[6, 2] + "," + arr2d[6, 3] + "," + arr2d[6, 4] + "," + arr2d[6, 5] + "," + arr2d[6, 6] + "," + arr2d[6, 7] + "," + arr2d[6, 8] + "," + arr2d[6, 9] + "]\n" +
             "[" + arr2d[7, 0] + "," + arr2d[7, 1] + "," + arr2d[7, 2] + "," + arr2d[7, 3] + "," + arr2d[7, 4] + "," + arr2d[7, 5] + "," + arr2d[7, 6] + "," + arr2d[7, 7] + "," + arr2d[7, 8] + "," + arr2d[7, 9] + "]\n" +
             "[" + arr2d[8, 0] + "," + arr2d[8, 1] + "," + arr2d[8, 2] + "," + arr2d[8, 3] + "," + arr2d[8, 4] + "," + arr2d[8, 5] + "," + arr2d[8, 6] + "," + arr2d[8, 7] + "," + arr2d[8, 8] + "," + arr2d[8, 9] + "]\n" +
             "[" + arr2d[9, 0] + "," + arr2d[9, 1] + "," + arr2d[9, 2] + "," + arr2d[9, 3] + "," + arr2d[9, 4] + "," + arr2d[9, 5] + "," + arr2d[9, 6] + "," + arr2d[9, 7] + "," + arr2d[9, 8] + "," + arr2d[9, 9] + "]\n");


        Debug.Log("[" + needsChecking[0, 0] + "," + needsChecking[0, 1] + "," + needsChecking[0, 2] + "," + needsChecking[0, 3] + "," + needsChecking[0, 4] + "," + needsChecking[0, 5] + "," + needsChecking[0, 6] + "," + needsChecking[0, 7] + "," + needsChecking[0, 8] + "," + needsChecking[0, 9] + "]\n" +
            "[" + needsChecking[1, 0] + "," + needsChecking[1, 1] + "," + needsChecking[1, 2] + "," + needsChecking[1, 3] + "," + needsChecking[1, 4] + "," + needsChecking[1, 5] + "," + needsChecking[1, 6] + "," + needsChecking[1, 7] + "," + needsChecking[1, 8] + "," + needsChecking[1, 9] + "]\n" +
            "[" + needsChecking[2, 0] + "," + needsChecking[2, 1] + "," + needsChecking[2, 2] + "," + needsChecking[2, 3] + "," + needsChecking[2, 4] + "," + needsChecking[2, 5] + "," + needsChecking[2, 6] + "," + needsChecking[2, 7] + "," + needsChecking[2, 8] + "," + needsChecking[2, 9] + "]\n" +
             "[" + needsChecking[3, 0] + "," + needsChecking[3, 1] + "," + needsChecking[3, 2] + "," + needsChecking[3, 3] + "," + needsChecking[3, 4] + "," + needsChecking[3, 5] + "," + needsChecking[3, 6] + "," + needsChecking[3, 7] + "," + needsChecking[3, 8] + "," + needsChecking[3, 9] + "]\n" +
             "[" + needsChecking[4, 0] + "," + needsChecking[4, 1] + "," + needsChecking[4, 2] + "," + needsChecking[4, 3] + "," + needsChecking[4, 4] + "," + needsChecking[4, 5] + "," + needsChecking[4, 6] + "," + needsChecking[4, 7] + "," + needsChecking[4, 8] + "," + needsChecking[4, 9] + "]\n" +
             "[" + needsChecking[5, 0] + "," + needsChecking[5, 1] + "," + needsChecking[5, 2] + "," + needsChecking[5, 3] + "," + needsChecking[5, 4] + "," + needsChecking[5, 5] + "," + needsChecking[5, 6] + "," + needsChecking[5, 7] + "," + needsChecking[5, 8] + "," + needsChecking[5, 9] + "]\n" +
             "[" + needsChecking[6, 0] + "," + needsChecking[6, 1] + "," + needsChecking[6, 2] + "," + needsChecking[6, 3] + "," + needsChecking[6, 4] + "," + needsChecking[6, 5] + "," + needsChecking[6, 6] + "," + needsChecking[6, 7] + "," + needsChecking[6, 8] + "," + needsChecking[6, 9] + "]\n" +
             "[" + needsChecking[7, 0] + "," + needsChecking[7, 1] + "," + needsChecking[7, 2] + "," + needsChecking[7, 3] + "," + needsChecking[7, 4] + "," + needsChecking[7, 5] + "," + needsChecking[7, 6] + "," + needsChecking[7, 7] + "," + needsChecking[7, 8] + "," + needsChecking[7, 9] + "]\n" +
             "[" + needsChecking[8, 0] + "," + needsChecking[8, 1] + "," + needsChecking[8, 2] + "," + needsChecking[8, 3] + "," + needsChecking[8, 4] + "," + needsChecking[8, 5] + "," + needsChecking[8, 6] + "," + needsChecking[8, 7] + "," + needsChecking[8, 8] + "," + needsChecking[8, 9] + "]\n" +
             "[" + needsChecking[9, 0] + "," + needsChecking[9, 1] + "," + needsChecking[9, 2] + "," + needsChecking[9, 3] + "," + needsChecking[9, 4] + "," + needsChecking[9, 5] + "," + needsChecking[9, 6] + "," + needsChecking[9, 7] + "," + needsChecking[9, 8] + "," + needsChecking[9, 9] + "]\n");
    }


}

