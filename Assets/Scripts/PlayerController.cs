using UnityEngine;
using System.Collections;

/* PlayerController - Ensures the ball moves relative to the camera, without the use of camera's Y axis.
 * Updates the pickupsCollected amount when the player collides with a pickable gameObject.
 * Allows the player to jump.
 * 
 * Reference: https://www.youtube.com/watch?v=N34eNLzzfvQ
 */

public class PlayerController : MonoBehaviour 
{	
	public float speed; // The speed of the player.
    public float jumpForce; // Sets the player's jump force.

    [SerializeField]
    private GameObject pickupSound;
    [SerializeField]
    private GameObject dontPickupSound;
    [SerializeField]
    private GameObject jumpSound;

    [SerializeField]
    private GameObject pickupText; // Updates the pickup text on the HUD.

    private bool jumpingAllowed;
    private Vector3 jump;
	private Rigidbody rb; // The rigidbody of the player, used for velocity.

    private int pickupsCollected;
        
	void Start()
	{
        pickupsCollected = 0;
        jumpingAllowed = true;
        jump.Set(0.0f, 1.0f, 0.0f); // Sets the default height of the jump, multiplied later by the jumpForce.
        rb = gameObject.GetComponent<Rigidbody>();
	}

    // These two functions below make sure the player firstly collides with the level before jumping.
    void OnCollisionEnter(Collision _col)
    {
        if (_col.gameObject.tag == "Level")
        {
            jumpingAllowed = true;
        }
    }

    void OnCollisionExit(Collision _col)
    {
        if (_col.gameObject.tag == "Level")
        {
            jumpingAllowed = false;
        }
    }
    
    // Returns the amount of pickups collected.
    public int GetPickUps()
    {
        return pickupsCollected;
    }
	
    // This Update() function makes sure the player moves relative to the camera, and allows him to jump.
	void Update ()
	{
        Vector3 movement = Vector3.zero;

        // Takes the input from the player and stores it.
        float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

        // Sets the initial movement provided by the input.
        movement.Set(moveHorizontal, 0, moveVertical);

        /* In case the movement's magnitude is above 1,
         * it is normalized to ensure that there is no
         * unnatural movement in-game.
         */
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        // Transforms the input movement into a direction relative to the camera.
        Vector3 direction = Camera.main.transform.TransformDirection(movement);
        /* Removes the Y axis movement from the direction vector.
         * Otherwise, by looking at the ground the ball would not move at all.
         */
        direction.Set(direction.x, 0, direction.z);
    
        // Updates the movement with the direction of the camera.
        movement = direction.normalized * movement.magnitude;

        // Adds the corrected movement to the ball's rigidbody.
        rb.AddForce(movement * speed * Time.deltaTime);

        // Checks if the player pressed Space and if he is on allowable terrain.
        if (Input.GetKeyDown(KeyCode.Space) && jumpingAllowed)
        {
            // Adds the upwards jump force.
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            jumpingAllowed = false;
            // Plays the jump sound.
            jumpSound.GetComponent<AudioSource>().Play();
        }
    }
	
    // Plays a sound and makes changes to the pickupsCollected variable depending on which pickup has been picked up.
	void OnTriggerEnter(Collider _other) 
	{
		if (_other.gameObject.tag == "PickUp")
        {
			_other.gameObject.SetActive (false);
            ++pickupsCollected;
            pickupSound.GetComponent<AudioSource>().Play();
		}

        else if (_other.gameObject.tag == "DontPickUp")
        {
			_other.gameObject.SetActive (false);
            --pickupsCollected;
            pickupText.GetComponent<PickupDisplay>().StartFlashing();
            dontPickupSound.GetComponent<AudioSource>().Play();
        }
	}
}
