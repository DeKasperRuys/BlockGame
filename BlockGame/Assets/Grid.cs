using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public float[,] TheGrid;
    int Vertical, Horizontal, Colums,Rows;
    public Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        Vertical = (int)Camera.main.orthographicSize;
        Horizontal = Vertical * (Screen.width / Screen.height);
        Colums = 4;
        Rows = 4;
        TheGrid = new float[Colums, Rows];
        for (int i = 0; i < Colums; i++)
        {
            for (int j = 0; j < Rows; j++)
            {
                TheGrid[i, j] = Random.Range(0.0f,1.0f);
                SpawnTile(i, j, TheGrid[i, j]);
            }
        }
       
    }

    // Update is called once per frame
    private void SpawnTile(int x, int y, float value)
    {
        GameObject g = new GameObject("X: "+x+"Y: "+y);
        g.transform.position = new Vector3(x-(Horizontal),y-(Vertical));
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value,value,value);
    }
}
