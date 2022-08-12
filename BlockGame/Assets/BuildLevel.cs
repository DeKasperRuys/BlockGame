using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildLevel : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    public GameObject grid;

    public Sprite tileTexture; 

    public float divider = 1.795f;


    public void GenerateGrid(int[,] levelToGenerate)
    {

        for (int x = 0; x < levelToGenerate.GetLength(0); x++)
        {
            for (int y = 0; y < levelToGenerate.GetLength(1); y++)
            {

                if (x + y != 0)
                {
                    if (PlayerPrefs.GetInt("colorCode") != 6)
                    {
                        if (levelToGenerate[x, y] == PlayerPrefs.GetInt("colorCode"))
                        {
                            levelToGenerate[x, y] = 6;
                        }
                    }
                }

                Debug.Log("The chosen colour code in build level is : " + PlayerPrefs.GetInt("colorCode"));

                var spawnedTile = new GameObject($"Tile{x}{y}");
                RectTransform spawnedTileTransform = spawnedTile.AddComponent<RectTransform>();
                spawnedTileTransform.transform.SetParent(grid.transform);
                spawnedTileTransform.localScale = Vector3.one;
                spawnedTileTransform.anchorMin = new Vector2(0f, 1f);
                spawnedTileTransform.anchorMax = new Vector2(0f, 1f);
                spawnedTileTransform.pivot = new Vector2(0.5f, 0.5f);
                spawnedTileTransform.anchoredPosition = new Vector2((30 * y) + 15, (-30 * x) - 45);
                spawnedTileTransform.sizeDelta = new Vector2(30, 30);
                Image spawnedTileImage = spawnedTile.AddComponent<Image>();
                spawnedTileImage.sprite = tileTexture;



                if (levelToGenerate[x, y] == 0)
                {
                    spawnedTileImage.color = Color.red;
                }
                if (levelToGenerate[x, y] == 1)
                {
                    spawnedTileImage.color = Color.green;
                }
                if (levelToGenerate[x, y] == 2)
                {
                    spawnedTileImage.color = Color.blue;
                }
                if (levelToGenerate[x, y] == 3)
                {
                    spawnedTileImage.color = new Color(1.0f, 0.53f, 0.17f); //orange
                }
                if (levelToGenerate[x, y] == 4)
                {
                    spawnedTileImage.color = Color.magenta;
                }
                if (levelToGenerate[x, y] == 5)
                {
                    spawnedTileImage.color = Color.yellow;
                }
                if (levelToGenerate[x, y] == 6)
                {
                    spawnedTileImage.color = Color.cyan;
                }
            }

        }

    }
}
