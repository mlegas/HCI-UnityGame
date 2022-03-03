using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// WinScreem - Sets the win canvas.

public class WinScreen : MonoBehaviour
{
    void Awake()
    {
        // Hides the win canvas when starting the scene.
        gameObject.SetActive(false);
    }

    // Restarts the level.
    public void Restart()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // Returns to the main menu.
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
