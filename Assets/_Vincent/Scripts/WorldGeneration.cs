using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] int worldWidth;
    [SerializeField] int worldHeight;

    GameObject[,] m_world;

    [SerializeField] Ore[] oresList;
    private void Awake()
    {
        m_world = new GameObject[worldWidth, worldHeight];
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateWorld(worldWidth, worldHeight));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Istantiates an object for every cell on the grid
    public IEnumerator GenerateWorld(int width, int height)
    {
        for(int y = 0;  y< height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject block = CheckForOre(x, y);

                if (block == null) 
                { 
                    Debug.Log("No Block found"); 
                    break; 
                }
                Vector2 position = new Vector2(x, -y);

                Instantiate(block, position, Quaternion.identity, transform);
                m_world[x, y] = block;

                yield return new WaitForEndOfFrame();
            }
        }
    }

    // Checks which ore should be spawned on location
    public GameObject CheckForOre(int x, int y)
    {
        float spawnrate = Random.value;

        return oresList[0].m_Ore;
    }
}
