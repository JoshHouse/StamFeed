using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

    // Advances to play the game when a button is pressed
    public void PlayGame()
    {
        Debug.Log("Button Was Pressed");
        // Load the game scene to play
        SceneManager.LoadScene("Game");
    }

    // Closes game when a button is pressed
    public void ExitGame()
    {
        Debug.Log("QUIT"); // Debug message for testing purposes
        Application.Quit();
    }

}
