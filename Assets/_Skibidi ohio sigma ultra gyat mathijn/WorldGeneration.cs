using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerationcopy : MonoBehaviour
{
    [SerializeField] int worldWidth;
    [SerializeField] int worldHeight;

    GameObject[,] m_world;

    [SerializeField] GameObject[] oresList; 

    [SerializeField] float ore1SpawnRate = 0.7f; 
    [SerializeField] float ore2SpawnRate = 0.1f; 
    [SerializeField] float ore3SpawnRate = 0.1f; 
    [SerializeField] float ore4SpawnRate = 0.1f;
    [SerializeField] int mingeenorespawn = 5;

    private void Awake()
    {
        m_world = new GameObject[worldWidth, worldHeight];
    }

    void Start()
    {
        StartCoroutine(GenerateWorld(worldWidth, worldHeight));
    }

    // Generates the world grid
    public IEnumerator GenerateWorld(int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject block = CheckForOre(x, y); 
                Vector2 position = new Vector2(x, -y);

                Instantiate(block, position, Quaternion.identity, transform); 
                m_world[x, y] = block;

                yield return new WaitForEndOfFrame();
            }
        }
    }

    private GameObject CheckForOre(int x, int y)
    {
        float randomValue = Random.Range(0f, 1f);

        if (y > mingeenorespawn - 1) {
            if (randomValue < ore1SpawnRate)
            {
                return oresList[0];
            }
            else if (randomValue < ore1SpawnRate + ore2SpawnRate)
            {
                return oresList[1]; 
            }
            else if (randomValue < ore1SpawnRate + ore2SpawnRate + ore3SpawnRate)
            {
                return oresList[2];
            }
            else
            {
                return oresList[3];
            }
        } else { return oresList[0]; }
        
    }
}
