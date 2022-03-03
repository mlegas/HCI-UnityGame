using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// PauseMenu - Hides the pauseMenu when awake and provides functions for the buttons used on the pauseMenu.

public class PauseMenu : MonoBehaviour {

    public bool pauseOn;

	void Awake ()
    {
        // Hides the pause menu.
        gameObject.SetActive(false);
        pauseOn = false;
	}
     
    // This function unpauses the game when the players clicks on the Return button.
    public void Unpause()
    {
        pauseOn = false;
        // Sets the time back to normal.
        Time.timeScale = 1.0f;
        // Hides the pauseMenu.
        gameObject.SetActive(false);
        // Allows the player camera movement.
        Camera.main.GetComponent<CameraController>().enabled = true;
        // Hides the cursor.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // This function restars the scene.
    public void Restart()
    {
        pauseOn = false;
        // Sets the time back to normal to allow movement on the reloaded scene.
        Time.timeScale = 1.0f;
        // Ensures the pause menu is hidden when the scene is reloaded.
        gameObject.SetActive(false);

        // Takes the current scene and reloads it.
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    // This function takes the player back to the main menu.
    public void MainMenu()
    {
        pauseOn = false;
        // Sets the time back to normal to allow movement of the ball in the Main Menu.
        Time.timeScale = 1.0f;
        // Ensures the pause menu is hidden when the scene is loaded.
        gameObject.SetActive(false);
        // Loads the Main Menu scene.
        SceneManager.LoadScene("MainMenu");
    }
}
