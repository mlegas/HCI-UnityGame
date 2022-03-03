using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PauseManager - Displays the pause canvas when used. Has to be in a separate script, as the pauseMenu is inactive when awake.

public class PauseManager : MonoBehaviour {

    [SerializeField]
    private Canvas pauseMenu;

    void Update()
    {
        // Checks if the Escape button has been pressed and if the pause menu is not already active.
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.GetComponent<PauseMenu>().pauseOn)
        {
            pauseMenu.GetComponent<PauseMenu>().pauseOn = true;
            // Stops the time to ensure that no physics manipulation is allowed.
            Time.timeScale = 0.0f;
            // Displays the pause menu.
            pauseMenu.gameObject.SetActive(true);
            // Stops the camera from moving.
            Camera.main.GetComponent<CameraController>().enabled = false;

            // Displays the cursor to allow the player to click on buttons.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
