using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{

    public LoadSceneByIndex sceneman;
    public FlowerManager flowman;
    public Timer timer;

    private bool gameIsOver = false;

    void Update() // CHANGE WIN CONDITIONS
    {
        // If the timer ends and the game isn't over, transition to an ending scene
        if (timer.timeIsUp() && !gameIsOver)
        {
            gameIsOver = true;

            // Determine which ending to trigger based on flower points
            if (flowman.GetFlowerPoints() < 5)
            {
                sceneman.LoadScene(4); // Load scene for Ending One
            }
            else if (flowman.GetFlowerPoints() >= 5 && flowman.GetFlowerPoints() < 10)
            {
                sceneman.LoadScene(5); // Load scene for Ending Two
            }
            else if (flowman.GetFlowerPoints() >= 10)
            {
                sceneman.LoadScene(6); // Load scene for Ending Three
            }
        }
    }

    // Restart the current game scene (e.g., when restart button is clicked)
    public void RestartGame()
    {
        gameIsOver = false;
        Time.timeScale = 1f; // Resume the game
        sceneman.LoadScene(3); // Reload to gameplay -- MAYBE CHANGE
    }

    // Return to the main menu (e.g., from the win or lose menu)
    public void LoadMainMenu()
    {
        gameIsOver = false;
        sceneman.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked. Exiting the game.");
        Application.Quit();
    }
}
