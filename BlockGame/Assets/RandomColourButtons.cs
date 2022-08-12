using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomColourButtons : MonoBehaviour
{
    int count = 0;
    int randomColorNumber;
    [SerializeField] private int buttonAmount = 2;
    [SerializeField] public GameObject buttonPrefab;
    [SerializeField] public Transform buttonContainer;

    void Start()
    {
        
        for (int i = 1; i < buttonAmount+1; i++)
        {
            int tempint = i - 1;
            randomColorNumber = Random.Range(0, 7);
            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {

                PlayerPrefs.SetInt("level", tempint);
                Debug.Log("level"+i);
                SceneManager.LoadScene("game");

            });
            newButton.transform.SetParent(buttonContainer);


            if (randomColorNumber == 0)
            {
                newButton.GetComponent<Image>().color = StaticData.Red;
            }
            if (randomColorNumber == 1)
            {
                newButton.GetComponent<Image>().color = StaticData.Green;
            }
            if (randomColorNumber == 2)
            {
                newButton.GetComponent<Image>().color = StaticData.Blue;
            }
            if (randomColorNumber == 3)
            {
                newButton.GetComponent<Image>().color = StaticData.Orange;
            }
            if (randomColorNumber == 4)
            {
                newButton.GetComponent<Image>().color = StaticData.Purple;
            }
            if (randomColorNumber == 5)
            {
                newButton.GetComponent<Image>().color = StaticData.Yellow;
            }
            if (randomColorNumber == 6)
            {
                newButton.GetComponent<Image>().color = StaticData.Cyan;
            }
        }



        /*
        foreach (Transform child in transform)
        {
            count++;
            randomColorNumber = Random.Range(0, 6);

            //Set button text to the correct level
            child.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();

            int tempint = count;

            child.GetComponent<Button>().onClick.AddListener(() =>
            {

                PlayerPrefs.SetInt("level", tempint - 1);
                SceneManager.LoadScene("game");

            });


            if (randomColorNumber ==0)
            {
                child.GetComponent<Image>().color = StaticData.Red;
            }
            if (randomColorNumber == 1)
            {
                child.GetComponent<Image>().color = StaticData.Green;
            }
            if (randomColorNumber == 2)
            {
                child.GetComponent<Image>().color = StaticData.Blue;
            }
            if (randomColorNumber == 3)
            {
                child.GetComponent<Image>().color = StaticData.Orange;
            }
            if (randomColorNumber == 4)
            {
                child.GetComponent<Image>().color = StaticData.Purple;
            }
            if (randomColorNumber == 5)
            {
                child.GetComponent<Image>().color = StaticData.Yellow;
            }
            if (randomColorNumber == 6)
            {
                child.GetComponent<Image>().color = StaticData.Cyan;
            }
            
            
        }*/


    }



}
