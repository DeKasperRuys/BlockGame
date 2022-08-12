using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerateLevelButtons : MonoBehaviour
{
    int count = 0;
    int randomColorNumber;
    private int levelReached;
    private int buttonAmount = 1;
    [SerializeField] public GameObject buttonPrefab;
    [SerializeField] public Transform buttonContainer;
    

   
    
    void Start()
    {

        levelReached = PlayerPrefs.GetInt("levelReached");

        buttonAmount = StaticData.levelList.Count;

        if (levelReached < 1) //First time played = 0 && I dont want to set to 1 when I have a higher reachedLevel
        {
            PlayerPrefs.SetInt("levelReached", 1);
            levelReached = PlayerPrefs.GetInt("levelReached");
        }


        for (int i = 1; i < buttonAmount+1; i++)
        {
            int tempint = i - 1;
            randomColorNumber = Random.Range(0, 7);
            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {

                PlayerPrefs.SetInt("level", tempint);
                SceneManager.LoadScene("game");

            });
            newButton.transform.SetParent(buttonContainer);


            if (i > levelReached)
            {
                newButton.GetComponent<Button>().interactable = false;
            }


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

        Debug.Log("levelreached is set on " + PlayerPrefs.GetInt("levelReached"));



    }



}
