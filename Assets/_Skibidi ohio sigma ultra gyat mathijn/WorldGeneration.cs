using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; // For async/await and multithreading
using System;

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
        // Start world generation asynchronously
        GenerateWorldAsync(worldWidth, worldHeight);
    }

    // Async method for world generation
    public async void GenerateWorldAsync(int width, int height)
    {
        // Start the CPU-bound task in a separate thread
        GameObject[,] worldData = await Task.Run(() => GenerateWorldData(width, height));

        // Update the world (instantiate game objects) on the main thread
        StartCoroutine(InstantiateWorld(worldData));
    }

    // Generate world data on a separate thread
    private GameObject[,] GenerateWorldData(int width, int height)
    {
        GameObject[,] tempWorld = new GameObject[width, height];
        System.Random random = new System.Random(); // Use System.Random for background thread

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                tempWorld[x, y] = CheckForOre(x, y, random);
            }
        }

        return tempWorld;
    }

    // Coroutine to instantiate the world on the main thread
    private IEnumerator InstantiateWorld(GameObject[,] worldData)
    {
        for (int y = 0; y < worldData.GetLength(1); y++)
        {
            for (int x = 0; x < worldData.GetLength(0); x++)
            {
                GameObject block = worldData[x, y];
                Vector2 position = new Vector2(x, -y);

                // Instantiate the block on the main thread
                Instantiate(block, position, Quaternion.identity, transform);
            }

            // Yield after an entire row is processed to keep the main thread responsive
            yield return null;
        }
    }

    // Use System.Random for the background thread
    private GameObject CheckForOre(int x, int y, System.Random random)
    {
        double randomValue = random.NextDouble(); // Generate random value using System.Random
        if (y == 0) { return oresList[4]; }
        if (y == worldHeight - 1) { return oresList[5]; }
        if (y < 3) { return oresList[6]; }
        if (y > mingeenorespawn - 1)
        {
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
        }
        else { return oresList[0]; }
    }
}
