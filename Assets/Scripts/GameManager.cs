using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int foodCollectCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinConditionTracker()
    {
        foodCollectCount++;

        if (foodCollectCount == 15)
        {
            SceneManager.LoadScene("You Win");
        }
    }
}
