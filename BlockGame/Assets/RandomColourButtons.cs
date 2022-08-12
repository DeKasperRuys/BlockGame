using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomColourButtons : MonoBehaviour
{

    int randomColorNumber;
    int count =0;
    void Start()
    {

        foreach (Transform child in transform)
        {
            count++;
            randomColorNumber = Random.Range(0, 6);
            child.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();
            int tempint = count;

            child.GetComponent<Button>().onClick.AddListener(() =>
            {

                PlayerPrefs.SetInt("level", tempint - 1);
                SceneManager.LoadScene("game");

            });


            if (randomColorNumber ==0)
            {
                child.GetComponent<Image>().color = Color.red; 
            }
            if (randomColorNumber == 1)
            {
                child.GetComponent<Image>().color = Color.green; ;
            }
            if (randomColorNumber == 2)
            {
                child.GetComponent<Image>().color = Color.blue; 
            }
            if (randomColorNumber == 3)
            {
                child.GetComponent<Image>().color = new Color(1.0f, 0.53f, 0.17f); //orange
            }
            if (randomColorNumber == 4)
            {
                child.GetComponent<Image>().color = Color.magenta; 
            }
            if (randomColorNumber == 5)
            {
                child.GetComponent<Image>().color = Color.yellow; 
            }
            if (randomColorNumber == 6)
            {
                child.GetComponent<Image>().color = Color.cyan; 
            }
            
            
        }


    }

   
}
