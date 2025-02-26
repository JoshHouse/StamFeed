using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;

    private int xRange = 15; // Bound for left and right in game
    private int zTop = 15; // Bound for top in game
    private int zBottom = 0; // Bound for bottom in game

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        // Moves the player up, down, left, and right according to the inputs received on the specific axis.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate((horizontalInput * speed * Time.deltaTime), 0, (verticalInput * speed * Time.deltaTime));

        // Sets the bounds on horizontal movement
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, 0, transform.position.z);
        } 
        else if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, 0, transform.position.z);
        } 

        // Sets the bounds on vertical movement
        if (transform.position.z > zTop)
        {
            transform.position = new Vector3(transform.position.x, 0, zTop);
        } 
        else if (transform.position.z < -zBottom)
        {
            transform.position = new Vector3(transform.position.x, 0, -zBottom);
        }

    }
}
