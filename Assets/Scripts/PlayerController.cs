using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;                    // Instance of the player controller

    [SerializeField] private float speed;                       // How fast the player moves - is set in editor

    // Gets Unity parameters for moving on the horizontal/vertical axis
    private float horizontalInput;
    private float verticalInput;

    private int xRange = 15;                                    // Bound for left and right in game
    private int zTop = 15;                                      // Bound for top in game
    private int zBottom = 0;                                    // Bound for bottom in game

    // The statuses the player can be in. 2 means the player has lost, 3 means the player won
    public enum Status { ALIVE = 0, DYING = 1, DEAD = 2, WIN = 3,}      
    [HideInInspector] public int currStatus;                    // Player's current status

    SkinnedMeshRenderer mesh;                                   // References the SkinnedMeshRenderer attached to the character farmer
    BoxCollider box3D;                                          // References the BoxCollider attached to the player

    // Aeake is called when the object becomes active
    void Awake()
    {
         currStatus = (int) Status.ALIVE;

        // Ensure only one instance of the player controller exists in this game.
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    private void Start()
    {
        mesh = transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>();
        box3D = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        // Moves the player up, down, left, and right according to the inputs received on the specific axis.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate((horizontalInput * speed * Time.deltaTime), 0, (verticalInput * speed * Time.deltaTime));

        switch (currStatus)
        {
            case (int) Status.ALIVE:                                   // Player can only move while they are in the alive status
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
                break;
            case (int) Status.DYING:                                   // Player was hit - Start the process of the player's death and eliminate any further collisions and movements
                speed = 0;
                box3D.enabled = false;
                StartCoroutine("DeathRoutine");
                break;
            case (int) Status.DEAD:                                    // Player is dead - Trigger the game over scene to load in
                gameObject.SetActive(false);                           // Turn off the game object
                break;
            case (int) Status.WIN:                                     // PLayer has won - Trigger any necessary win commands/winning scene
                break;
        }

    }

    public IEnumerator DeathRoutine()
    {
        
        // Change the player's status if the coroutine was somehow started while the status isn't dying
        if (currStatus != (int) Status.DYING)
            currStatus = (int) Status.DYING;

        // First for loop: Change the color to red and material shader to one that can be made transparent
        for (int i = 0; i < mesh.materials.Length; i++) 
        {
            // The farmer object has multiple materials. The for loop cycles through them all
            mesh.materials[i].SetColor("_Color", Color.red);                        // Set each material's color to red
            mesh.materials[i].shader = Shader.Find("Transparent/Diffuse");          // This shader can be made transparent
        }

        yield return new WaitForSeconds(1);                                         // Wait for 1 second

        // Second for loop: Make the player transparent
        Color deadColor = new Color(1, 0, 0, 0); // Create a color with the a value set to 0 for transparency
        for (int i = 0; i < mesh.materials.Length; i++)
            mesh.materials[i].SetColor("_Color", deadColor);
        
        yield return new WaitForSeconds(0.5f);                                      // Wait for half a second

        currStatus = (int) Status.DEAD;                                             // Set status to dead

        yield return null;
    }

}
