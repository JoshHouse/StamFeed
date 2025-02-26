using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float upperBoundZ = 21;
    private float lowerBoundZ = -11;
    private float leftBoundX = -31;
    private float rightBoundX = 31;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > upperBoundZ ||
            transform.position.z < lowerBoundZ ||
            transform.position.x < leftBoundX ||
            transform.position.x > rightBoundX)
        {
            gameObject.SetActive(false);
        }
    }
}
