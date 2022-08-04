using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelComplete : MonoBehaviour
{
    //0 is hoogte array
    //1 is  lengte array

    [SerializeField] public GameManager gameManager;
    public bool Checker(int[,] array, int value)
    {
        for (int i = 0; i < gameManager.copyOfLevel.GetLength(1); i++)
        {
            for (int j = 0; j < gameManager.copyOfLevel.GetLength(0); j++)
            {
                //Debug.Log("Checking [" + j + "," + i+"]" + " and it is = " + arr2d[j,i] );
                if (gameManager.copyOfLevel[j, i] != value)
                {
                    return false;
                }

            }
        }
        return true;

    }
}
