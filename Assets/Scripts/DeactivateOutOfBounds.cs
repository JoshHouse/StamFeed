using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOutOfBounds : MonoBehaviour
{
    // Default values set but are also adjustable in the unity editor
    public float upperBoundZ = 21;      // Top map boarder Z value
    public float lowerBoundZ = -11;     // Bottom map boarder Z value
    public float leftBoundX = -31;      // Left map boarder X value
    public float rightBoundX = 31;      // Right map boarder X value

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If any values exceed the boundaries it sets the object to inactive (so the pools can use them again)
        if (transform.position.z > upperBoundZ ||
            transform.position.z < lowerBoundZ ||
            transform.position.x < leftBoundX ||
            transform.position.x > rightBoundX)
        {
            gameObject.SetActive(false);
        }
    }
}
