using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Set in the Unity editor
    public ObjectPool[] animalPools;    // Array of Animal Spawning Pools
    public float spawnDelay;            // Delay before the first animal spawns
    public float spawnInterval;         // Interval between the next spawn of an animal

    // Spawn Charging Vertically
    public float spawnRangeX = 20;     // The range on the X axis that animals can spawn when charging vertically
    public float spawnPosZ;            // Is not as simple as setting negative or positive for a spawn height on the Z axis
                                       // since the viewing plane is not centered on the Z axis so it is set when spawning

    // Spawn Charging Horizontally
    public float spawnRangeZ = 14;     // The range on the Z axis that animals can spawn when charging horizontally
    public float spawnPosX = 30;       // The spawn position on the x axis (positive or negative) to make animals spawn off screen

    private GameObject spawnedAnimal;   // Variable to hold the animal that was just spawned to set rotation


 
    // Start is called before the first frame update
    void Start()
    {
        // Calls SpawnRandomAnimal function after spawn delay at the speed spawnInterval
        InvokeRepeating("SpawnRandomAnimal", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns Random animal on top, bottom, left or right
    void SpawnRandomAnimal()
    {
        // Random values for spawning mechanics
        int poolIndex = Random.Range(0, animalPools.Length);    // Determines which pool to spawn from
        int spawnAxis = Random.Range(0, 4);                     // Determines which side of the screen to spawn on

        // Charging North
        if (spawnAxis == 0)
        {
            spawnPosZ = -10;                                    // Sets spawn position on the Z axis for Animals charging vertically
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);  // Calculates Spawn Position

            spawnedAnimal = animalPools[poolIndex].Spawn(spawnPos);                             // Calls ObjectPool spawn function
            spawnedAnimal.transform.rotation = Quaternion.Euler(0, 0, 0);                       // Sets newly spawned animal's rotation
        }

        // Charging East
        if (spawnAxis == 1)
        {
            Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));        // Calculates Spawn Position

            spawnedAnimal = animalPools[poolIndex].Spawn(spawnPos);                             // Calls ObjectPool spawn function
            spawnedAnimal.transform.rotation = Quaternion.Euler(0, 90, 0);                      // Sets newly spawned animal's rotation
        }

        // Charging South
        if (spawnAxis == 2)
        {
            spawnPosZ = 20;                                     // Sets spawn position on the Z axis for Animals charging vertically
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);  // Calculates Spawn Position

            spawnedAnimal = animalPools[poolIndex].Spawn(spawnPos);                             // Calls ObjectPool spawn function
            spawnedAnimal.transform.rotation = Quaternion.Euler(0, 180, 0);                     // Sets newly spawned animal's rotation
        }

        // Charging West
        if (spawnAxis == 3)
        {
            Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));         // Calculates Spawn Position

            spawnedAnimal = animalPools[poolIndex].Spawn(spawnPos);                             // Calls ObjectPool spawn function
            spawnedAnimal.transform.rotation = Quaternion.Euler(0, 270, 0);                     // Sets newly spawned animal's rotation
        }
    }
}
