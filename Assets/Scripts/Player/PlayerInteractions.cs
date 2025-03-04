using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    // Reference to Game Manager
    private GameManager gameManager;

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        gameManager = GameManager.instance;
    }

    // Called to determine the player object's action when it collides with a trigger collider.
    private void OnTriggerEnter(Collider collider)
    {

        // The player's collider hit an animal's collider
        if (collider.gameObject.CompareTag("Animal")) {
            PlayerController.instance.currStatus = (int) PlayerController.Status.DYING;
        }

        // The player's collider hit a piece of food's collider, collect it
        if (collider.gameObject.CompareTag("Food"))
        {
            gameManager.WinConditionTracker();
        }

    }

}
