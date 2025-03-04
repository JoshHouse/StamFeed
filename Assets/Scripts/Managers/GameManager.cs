using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Reference to the Game Manager
    public static GameManager instance;

    // Reference to Food UI
    public Text foodDisplay;

    // Food collection win condition and current count
    public int foodCollectMax = 12;
    private int foodCollectCount = 0;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure GameManager is a singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foodDisplay.text = foodCollectCount.ToString() + " / " + foodCollectMax.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Close game is ESC pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void WinConditionTracker()
    {
        foodCollectCount++;

        if (foodCollectCount == foodCollectMax)
        {
            SceneManager.LoadScene("You Win");
        }

        foodDisplay.text = foodCollectCount.ToString() + " / " + foodCollectMax.ToString();
    }
}
