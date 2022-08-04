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

    public void GenerateGrid(int[,] levelToGenerate)
    {

        for (int x = 0; x < levelToGenerate.GetLength(0); x++)
        {
            for (int y = 0; y < levelToGenerate.GetLength(1); y++)
            {

                if (x + y != 0)
                {
                    if (ChooseColour.chosenColourCode != 6)
                    {
                        if (levelToGenerate[x, y] == ChooseColour.chosenColourCode)
                        {
                            levelToGenerate[x, y] = 6;
                        }
                    }
                }




                var spawnedTile = Instantiate(tilePrefab, new Vector3(y / divider, -x / divider), transform.rotation);
                spawnedTile.name = $"Tile{x}{y}";


                spawnedTile.transform.parent = GameObject.Find("Grid").transform;
                if (levelToGenerate[x, y] == 0)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Red;
                }
                if (levelToGenerate[x, y] == 1)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Green;
                }
                if (levelToGenerate[x, y] == 2)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Blue;
                }
                if (levelToGenerate[x, y] == 3)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Orange;
                }
                if (levelToGenerate[x, y] == 4)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Purple;
                }
                if (levelToGenerate[x, y] == 5)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Yellow;
                }
                if (levelToGenerate[x, y] == 6)
                {
                    spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Cyan;
                }
            }

        }

    }
}
