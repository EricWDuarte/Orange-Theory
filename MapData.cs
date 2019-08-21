using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ColorToPrefab
{
    public string name = "default";
    public Color32 color = new Color32();
    public GameObject prefab;
}

public class MapData : MonoBehaviour {

    public Texture2D[] levelMap;
    public float[] height;
    public ColorToPrefab[] colorToPrefab;


    void Start () {
        for (int i = 0; i < levelMap.Length; i++)
        {
            LoadMap(i);
        }
	}

    public void LoadMap(int level)
    {
        // Read the image data from the file in StreamingAssets
        //string filePath = Application.dataPath + "/StreamingAssets/" + levelFileName;
        //byte[] bytes = System.IO.File.ReadAllBytes(filePath);

        //Texture2D levelMap = new Texture2D(2, 2);
        //levelMap.LoadImage(bytes);

        Texture2D map = levelMap[level];

        Color32[] allPixels = map.GetPixels32();
        int width = map.width;
        int height = map.height;


        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GetTileCtp(allPixels[width * y + x], new Vector2(x, y), level);
            }
        }
    }





    void GetTileCtp(Color32 color, Vector2 pos, int level)
    {
        if (color.a == 0)
        {
            return;
        }


        // NOTE: This isn't optimized. You should have a dictionary lookup for max speed
        foreach (ColorToPrefab ctp in colorToPrefab)
        {

            if (color.Equals(ctp.color))
            {
                GameObject clone = Instantiate(ctp.prefab, new Vector2(pos.x - 23.5f, pos.y - height[level]), Quaternion.identity, this.transform);
                return;
            }
        }

        Debug.LogError("Tile Of color: " + color + " not Found!");
    }
}
