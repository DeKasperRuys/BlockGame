using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseFillColor : MonoBehaviour
{
    public RectTransform X;

    private void Update()
    {
        if (PlayerPrefs.HasKey("colorCode"))
        {
            switch (PlayerPrefs.GetInt("colorCode"))
            {
                case 0:
                    X.localPosition = new Vector3(-168, -20);
                    break;
                case 1:
                    X.localPosition = new Vector3(-113, -20);
                    break;
                case 2:
                    X.localPosition = new Vector3(-58, -20);
                    break;
                case 3:
                    X.localPosition = new Vector3(-3, -20);
                    break;
                case 4:
                    X.localPosition = new Vector3(52, -20);
                    break;
                case 5:
                    X.localPosition = new Vector3(107, -20);
                    break;
                case 6:
                    X.localPosition = new Vector3(162, -20);
                    break;
                default:
                    break;
            }
        }
        else
        {
            PlayerPrefs.SetInt("colorCode", 0);
            X.localPosition = new Vector3(-168, -20);
        }
    }
    public void chooseColor(int index)
    {
        switch (index)
        {
            case 0:
                PlayerPrefs.SetInt("colorCode", 0);
                X.localPosition = new Vector3(-168, -20);
                break;
            case 1:
                PlayerPrefs.SetInt("colorCode", 1);
                X.localPosition = new Vector3(-113, -20);
                break;
            case 2:
                PlayerPrefs.SetInt("colorCode", 2);
                X.localPosition = new Vector3(-58, -20);
                break;
            case 3:
                PlayerPrefs.SetInt("colorCode", 3);
                X.localPosition = new Vector3(-3, -20);
                break;
            case 4:
                PlayerPrefs.SetInt("colorCode", 4);
                X.localPosition = new Vector3(52, -20);
                break;
            case 5:
                PlayerPrefs.SetInt("colorCode", 5);
                X.localPosition = new Vector3(107, -20);
                break;
            case 6:
                PlayerPrefs.SetInt("colorCode", 6);
                X.localPosition = new Vector3(162, -20);
                break;
            default:
                break;
        }
    }

}
