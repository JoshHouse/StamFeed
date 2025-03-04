using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Set in the Unity Editor
    public GameObject objectPrefab;     // Object to instantiate the pool with
    public int poolSize;                // The desired size of the pool

    private List<GameObject> pool;      // List of objects in the pool

    // Called before the start of the game to instantiate the pool immediately
    private void Awake()
    {
        pool = new List<GameObject>();  // Creation of the list of objects that will represent the pool

        // For loop creates the number of objects requested by the poolSize variable
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);     // Instantiates the desired object
            obj.SetActive(false);                           // Sets the object to false so the spawn function can use it
            pool.Add(obj);                                  // Adds the newly created object to the pool
        }
    }

    // Spawn function teleports object to the position it was requested to "spawn" in. Returns reference to the game object it spawned
    public GameObject Spawn(Vector3 position)
    {
        foreach(GameObject obj in pool)             // Loops through the pool
        {
            if (obj.activeSelf == false)            // Checks if the object is inactive (aka ready for use)
            {
                obj.SetActive(true);                // Sets the selected object to active
                obj.transform.position = position;  // Teleports the object to the requested position
                return obj;                         // Returns a reference to the spawned object
            }
        }

        return null;            // If the entire pool was active (meaning all objects are in use) returns null
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
