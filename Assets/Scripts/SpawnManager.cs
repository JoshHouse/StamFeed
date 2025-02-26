using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    // Spawning Vertically
    private float spawnRangeX = 20;
    private float spawnPosZ;
    // Spawning Horizontally
    private float spawnRangeZ = 14;
    private float spawnPosX = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int animalAxis = Random.Range(0, 4);

        // Charging North
        if (animalAxis == 0)
        {
            spawnPosZ = -10;
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0,0,0));
        }

        // Charging East
        if (animalAxis == 1)
        {
            Vector3 spawnPos = new Vector3(-spawnPosX, 0, Random.Range(0, spawnRangeZ));

            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 90, 0));
        }

        // Charging South
        if (animalAxis == 2)
        {
            spawnPosZ = 20;
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 180, 0));
        }

        // Charging West
        if (animalAxis == 3)
        {
            Vector3 spawnPos = new Vector3(spawnPosX, 0, Random.Range(0, spawnRangeZ));

            Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(0, 270, 0));
        }
    }
}
