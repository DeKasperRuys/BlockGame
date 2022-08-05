using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildLevel : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    private GameObject grid;

    private Sprite tileTexture; 

    public float divider = 1.795f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grid = GameObject.Find("Grid");
        tileTexture = Resources.Load<Sprite>("Sprites/RoundedSquare");
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

                Debug.Log("The chosen colour code in build level is : " + ChooseColour.chosenColourCode);





                //GameObject spawnedTile1 = new GameObject("testAAA");

                //Image spawnedTile1Image = spawnedTile1.AddComponent<Image>();
                //Texture2D tex = Resources.Load<Texture2D>("red");
                //image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                //spawnedTile1.transform.SetParent(canvas.transform);




                var spawnedTile = new GameObject($"Tile{x}{y}");
                RectTransform spawnedTileTransform = spawnedTile.AddComponent<RectTransform>();
                spawnedTileTransform.transform.SetParent(grid.transform);
                spawnedTileTransform.localScale = Vector3.one;
                spawnedTileTransform.anchorMin = new Vector2(0f, 1f); // setting position, will be on center
                spawnedTileTransform.anchorMax = new Vector2(0f, 1f); // setting position, will be on center
                spawnedTileTransform.pivot = new Vector2(0.5f, 0.5f); // setting position, will be on center
                spawnedTileTransform.anchoredPosition = new Vector2((30*x) + 15, (-30*y) - 45);
                spawnedTileTransform.sizeDelta = new Vector2(30, 30); // custom size
                Image spawnedTileImage = spawnedTile.AddComponent<Image>();
                spawnedTileImage.sprite = tileTexture;

                //var spawnedTile = Instantiate(tilePrefab, new Vector3(y / divider, -x / divider ), transform.rotation);
                //spawnedTile.name = $"Tile{x}{y}";
                //spawnedTile.transform.parent = GameObject.Find("Grid").transform;


                if (levelToGenerate[x, y] == 0)
                {
                    //spawnedTile.GetComponent<SpriteRenderer>().color = StaticData.Red;
                    //spawnedTile.GetComponent<Image>().color = StaticData.Red;
                    spawnedTileImage.color = StaticData.Red;
                }
                if (levelToGenerate[x, y] == 1)
                {
                    //spawnedTile.GetComponent<Image>().color = StaticData.Green;
                    spawnedTileImage.color = StaticData.Green;
                }
                if (levelToGenerate[x, y] == 2)
                {
                    //spawnedTile.GetComponent<Image>().color = StaticData.Blue;
                    spawnedTileImage.color = StaticData.Blue;
                }
                if (levelToGenerate[x, y] == 3)
                {
                    //spawnedTile.GetComponent<Image>().color = StaticData.Orange;
                    spawnedTileImage.color = StaticData.Orange;
                }
                if (levelToGenerate[x, y] == 4)
                {
                   // spawnedTile.GetComponent<Image>().color = StaticData.Purple;
                    spawnedTileImage.color = StaticData.Purple;
                }
                if (levelToGenerate[x, y] == 5)
                {
                    //spawnedTile.GetComponent<Image>().color = StaticData.Yellow;
                    spawnedTileImage.color = StaticData.Yellow;
                }
                if (levelToGenerate[x, y] == 6)
                {
                    //spawnedTile.GetComponent<Image>().color = StaticData.Cyan;
                    spawnedTileImage.color = StaticData.Cyan;
                }
            }

        }

    }
}
