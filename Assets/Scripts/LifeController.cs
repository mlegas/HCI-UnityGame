using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// LifeController - Detects if the player has fallen out of the level, and decreases the amount of lives if so.

public class LifeController : MonoBehaviour
{
    public int lives; // The amount of lives of the player.

    [SerializeField]
    private GameObject livesText; // Accesses the text on the HUD canvas.
    [SerializeField]
    private Canvas gameOver; // Triggers the game over is the player ran out of lives.
    [SerializeField]
    private GameObject startGround; // Takes the transform of the starting position to respawn the player.
    [SerializeField]
    private GameObject deathSound; // The Wilhelm Scream to play on respawn.

    private Rigidbody rb; // Takes the rigidbody of the ball.
	
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

	void Update ()
    {

        // Checks if the player has fallen down out of the level.
		if (transform.position.y < -30.0f && lives > 0)
        {
            lives -= 1;
            // Teleports the player back to the starting position.
            transform.position = startGround.transform.position;
            // Resets the player's velocity.
            rb.velocity = Vector3.zero;

            // Flashes the text in red to ensure the player knows that one of his lives has been deducted.
            livesText.GetComponent<LifeDisplay>().StartFlashing();
            // Plays the Wilhelm Scream.
            deathSound.GetComponent<AudioSource>().Play();
        }

        // Checks if the player has fallen down out of the level and if he has no lives left.
        if (transform.position.y < -30.0f && lives == 0)
        {
            deathSound.GetComponent<AudioSource>().Play();
            
            // Triggers the game over.
            gameOver.GetComponent<GameOver>().ChangeGameToOver(2);
        }

	}
}
