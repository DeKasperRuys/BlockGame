using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{

    // COLOURS fsdafasdfsd
     
    public static Color Red = new Color(0.8584f, 0.0283f, 0.0283f, 1);
    public static Color Green = new Color(0.0040f, 0.8584f, 0.0040f, 1);
    public static Color Blue = new Color(0.1856f, 0.1856f, 0.9150f, 1);
    public static Color Orange = new Color(1f, 0.5286f, 0.1745f, 1);
    public static Color Purple = new Color(0.7286f, 0.1752f, 0.9528f, 1);
    public static Color Yellow = new Color(1f, 1f, 0.0336f, 1);
    public static Color Cyan = new Color(0.1079f, 0.9150f, 0.9150f, 1);

    // LEVEL 1

    public static List<int[,]> levelList = new List<int[,]>
    {
    new int[10, 10]
        {
            {PlayerPrefs.GetInt("colorCode") ,1,2,1,3,0,0,0,0,0},
                            {1,2,1,3,1,0,1,2,1,3 },
                            {2,1,3,1,4,4,4,2,1,3 },
                            {1,3,1,4,1,0,1,4,1,3 },
                            {2,1,3,1,4,0,4,2,1,3 },
                            {2,1,3,1,4,0,1,2,1,3 },
                            {2,1,5,1,4,0,1,5,1,3 },
                            {2,1,3,1,4,0,1,2,1,3 },
                            {2,1,3,1,4,0,1,5,1,3 },
                            {2,1,3,1,4,0,1,2,1,3 }
        },
    new int[10, 10]
        {
            {PlayerPrefs.GetInt("colorCode") ,0,0,0,0,0,0,0,0,0},
                            {0,0,0,0,0,0,0,0,0,0 },
                            {0,0,0,0,0,0,0,0,0,0 },
                            {0,0,0,0,0,0,0,0,0,0 },
                            {2,2,2,2,2,2,2,2,2,2 },
                            {0,0,0,0,0,0,0,0,0,0 },
                            {0,0,0,0,0,0,0,0,0,0 },
                            {0,0,0,0,0,0,0,0,0,0 },
                            {0,0,0,0,0,0,0,0,0,0 },
                            {3,3,3,3,3,3,3,3,3,3 }
        }
    };



    public static List<bool[,]> levelCheckList = new List<bool[,]>
    {

    new bool[10, 10]
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
         },
    new bool[10, 10]
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
         }
     };
}
