using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete : MonoBehaviour
{
    //0 is hoogte array
    //1 is  lengte array
    public bool Checker(int[,] array, int value)
    {
        for (int i = 0; i < StaticData.level0.GetLength(1); i++)
        {
            for (int j = 0; j < StaticData.level0.GetLength(0); j++)
            {
                //Debug.Log("Checking [" + j + "," + i+"]" + " and it is = " + arr2d[j,i] );
                if (StaticData.level0[j, i] != value)
                {
                    return false;
                }

            }
        }
        return true;

    }
}
