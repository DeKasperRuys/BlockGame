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
    //public TextMeshPro TextMeshProObject;
    void TaskWithParameters(string message)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
    }
    // Start is called before the first frame update
    void Start()
    {
        


        foreach (Transform child in transform)
        {
            count++;
            randomColorNumber = Random.Range(0, 6);
            child.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();


            int tempint = count;
            //child.GetComponent<Button>().onClick.AddListener(() => levelSelector.SelectThisLevel("Level_" + tempint.ToString()));
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                GameManager.selectedLevel = tempint - 1;
                SceneManager.LoadScene("game");

            });


            if (randomColorNumber ==0)
            {
                child.GetComponent<Image>().color = StaticData.Red; 
            }
            if (randomColorNumber == 1)
            {
                child.GetComponent<Image>().color = StaticData.Green; ;
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
            
            
        }


    }

   
}
