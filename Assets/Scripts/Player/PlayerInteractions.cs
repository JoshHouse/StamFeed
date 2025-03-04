using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    // Called to determine the player object's action when it collides with a trigger collider.
    private void OnTriggerEnter(Collider collider)
    {

        // The player's collider hit an animal's collider
        if (collider.gameObject.CompareTag("Animal")) {
            PlayerController.instance.currStatus = (int) PlayerController.Status.DYING;
        }

        // The player's collider hit a piece of food's collider
        if (collider.gameObject.CompareTag("Food"))
        {
        }

    }

}
