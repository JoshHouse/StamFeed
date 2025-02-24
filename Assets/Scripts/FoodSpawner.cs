using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Time before each food spawn
    public float foodDelayMax;
    // Current time left before next food spawn
    private float foodDelay;

    // Furthest food can spawn on the x-axis
    public float xBound;
    // Position of food from ground
    public float yPos;
    // Furthest food can spawn on the z-axis
    public float zBound;

    // Array of food prefabs to spawn
    public GameObject[] foodPrefabs;

    // Start is called before the first frame update
    private void Start()
    {
        foodDelay = foodDelayMax;
    }

    // Update is called once per frame
    void Update()
    {
        // Countdown foodDelay
        foodDelay -= Time.deltaTime;

        // Spawn food when foodDelay seconds elapses, reset timer
        if (foodDelay <= 0.0f)
        {
            SpawnFood();

            foodDelay = foodDelayMax;
        }
    }

    // Spawns a random food at random location (within the bounds)
    void SpawnFood()
    {
        // Choose random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-xBound, xBound), yPos, Random.Range(-zBound, zBound));

        // Spawn random food at spawnPos
        Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], spawnPos, Quaternion.identity);
    }
}
