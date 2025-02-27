using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Seconds to elapse before next food spawns
    public float foodDelay;

    // Furthest food can spawn on the x-axis (boundary is symmetrical)
    public float xBound;
    // Position of food from ground
    public float yPos;
    // Furthest food can spawn on the z-axis (boundary is symmetrical)
    public float zBound;

    // Array of food prefabs to spawn
    public GameObject[] foodPrefabs;

    // List of food in the pool, each element points to an instantiated food in the Scene (that may or may not be active)
    private List<GameObject> foodPool;

    // Awake is called when the script instance is being loaded, before Start
    private void Awake()
    {
        // Create foodPool
        foodPool = new List<GameObject>();

        // Generate inactive foodPrefabs into foodPool
        foreach (GameObject food in foodPrefabs)
        {
            GameObject tempObj = Instantiate(food);
            tempObj.SetActive(false);
            foodPool.Add(tempObj);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Spawn food every foodDelay seconds
        InvokeRepeating("SpawnFood", foodDelay, foodDelay);

        // Randomize order of foodPool for next spawning
        ShuffleFood();
    }

    // Spawns a random food at random location (within the bounds)
    GameObject SpawnFood()
    {
        // Choose random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-xBound, xBound), yPos, Random.Range(-zBound, zBound));

        // Find first inactive food in foodPool
        foreach (GameObject food in foodPool)
        {
            if (food.activeSelf == false)
            {
                // Spawn food at spawnPos
                food.SetActive(true);
                food.transform.position = spawnPos;

                // Randomize order of foodPool for next spawning
                ShuffleFood();

                // Stop spawning (only spawns 1 food) and return the food
                return food;
            }
        }

        // No food inactive in foodPool, return null
        return null;
    }

    // Randomly shuffles the foodPool
    void ShuffleFood()
    {
        // Iterate down foodPool
        for (int i = foodPool.Count - 1; i > 0; i--)
        {
            // Find a random index from 0 to i (since max value is exclusive)
            int swapFoodIndex = Random.Range(0, i + 1);

            // Executes if both indecies point to different foods in foodPool, if not, skip to next iteration
            // The possibility of i == swapFoodIndex being true improves randomness, so sometimes the food at [i] stays where it is
            if (i != swapFoodIndex)
            {
                // Swap the food at i and swapFoodIndex
                GameObject temp = foodPool[i];
                foodPool[i] = foodPool[swapFoodIndex];
                foodPool[swapFoodIndex] = temp;
            }
        }
    }
}
