using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FinishLevel - Detects a collision between the finish ground and the player, and activates the win condition.

public class FinishLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject winSound;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Canvas hud;

    [SerializeField]
    private GameObject stars; // GameObjects holding the stars, which represent how well did the player finish the level.

    [SerializeField]
    private Canvas endScreen; // The "win" canvas.

    void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == "Player")
        {
            // These lines disallow the player from moving any more.
            player.GetComponent<PlayerController>().enabled = false;
            Camera.main.GetComponent<CameraController>().enabled = false;

            // Shows the cursor to allow for the player to click on the buttons located on the end game canvas.
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Stops the time to ensure that no physics manipulation is allowed.
            Time.timeScale = 0.0f;

            // Updates the progression of the player on this level.
            stars.GetComponent<StarDisplay>().levelFinished = true;
            
            // Plays the win sound.
            winSound.GetComponent<AudioSource>().Play();

            // Hides the HUD canvas and shows the end game canvas.
            hud.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
        }
    }
}