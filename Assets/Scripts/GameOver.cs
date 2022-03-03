using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// GameOver - Script for the canvas used if the player fails the level in some way. Has to be in a separate script, as the gameOver canvas is inactive when awake.

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Canvas hud;
    [SerializeField]
    private GameObject player;

    private bool doOnce;

	void Awake ()
    {
        doOnce = false;
        // Hides the game over canvas as the player doesn't automatically fail the level on the start.
        gameObject.SetActive(false);
	}

    // This function is invoked by other scripts detecting fail conditions.
    public void ChangeGameToOver(int _option)
    {
        if (!doOnce)
        {
            doOnce = true;
            // Stops the time to ensure that no physics manipulation is allowed.
            Time.timeScale = 0.0f;

            if (_option == 1)
            {
                transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().SetText("Your amount of pickups went below 0.");
            }

            if (_option == 2)
            {
                transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().SetText("You have lost all lives.");
            }

            if (_option == 3)
            {
                transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().SetText("Time has run out.");
            }

            // These lines disallow the player from moving any more.
            player.GetComponent<PlayerController>().enabled = false;
            Camera.main.GetComponent<CameraController>().enabled = false;

            // Shows the cursor to allow for the player to click on the buttons located on the game over canvas.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Hides the HUD canvas and shows the game over canvas.
            hud.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }

    // If the player clicks on the Restart button on the game over canvas, this will reload the scene.
    public void Restart()
    {
        // Brings the timescale back to normal.
        Time.timeScale = 1.0f;
        // Turns off the game over canvas to ensure it won't be active.
        gameObject.SetActive(false);

        // Gets the current scene and reloads it.
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        // Brings the timescale back to normal.
        Time.timeScale = 1.0f;
        // Turns off the game over canvas to ensure it won't be active.
        gameObject.SetActive(false);
        // Loads the main menu scene.
        SceneManager.LoadScene("MainMenu");
    }
}
