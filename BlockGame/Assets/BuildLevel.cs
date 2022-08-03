using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevel : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    public float divider = 1.795f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateGrid()
    {

        for (int x = 0; x < StaticData.level0.GetLength(0); x++)
        {
            for (int y = 0; y < StaticData.level0.GetLength(1); y++)
            {

                if (x + y != 0)
                {
                    if (ChooseColour.chosenColourCode != 6)
                    {
                        if (StaticData.level0[x, y] == ChooseColour.chosenColourCode)
                        {
                            StaticData.level0[x, y] = 6;
                        }
                    }
                }




                var spawnedTile = Instantiate(tilePrefab, new Vector3(y / divider, -x / divider), transform.rotation);
                spawnedTile.name = $"Tile{x}{y}";

                // spawnedTile.tag = x + "" + y;
                spawnedTile.transform.parent = GameObject.Find("Grid").transform;
                if (StaticData.level0[x, y] == 0)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Red;
                    //spawnedTile.Init(0, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (StaticData.level0[x, y] == 1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Green;
                    //spawnedTile.Init(1,Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (StaticData.level0[x, y] == 2)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Blue;
                    //spawnedTile.Init(2, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (StaticData.level0[x, y] == 3)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Orange;
                    //spawnedTile.Init(3, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (StaticData.level0[x, y] == 4)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Purple;
                    //spawnedTile.Init(4, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (StaticData.level0[x, y] == 5)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Yellow;
                    //spawnedTile.Init(5, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
                if (StaticData.level0[x, y] == 6)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Cyan;
                    //spawnedTile.Init(6, Red, Green, Blue, Orange, Cyan, Purple, Yellow);
                }
            }

        }

    }
}
