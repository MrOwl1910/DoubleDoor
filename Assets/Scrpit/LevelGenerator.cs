using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColortoPrefab[] ColorMappings;
    void Start()
    {
        GenerateLevel();   
    }
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y)
    {
        Color PixelColor = map.GetPixel(x, y);
        if (PixelColor.a == 0)
        {
            //pixel color is trasparent let's ignore it 
            return;
        }
        foreach (ColortoPrefab ColorMapping in ColorMappings) 
        {
            if (ColorMapping.Color.Equals(PixelColor))
            {
                Vector2 position = new Vector2(x, y);
                Instantiate(ColorMapping.Prefab, position, Quaternion.identity, transform);
            }
        }
    }
}//class