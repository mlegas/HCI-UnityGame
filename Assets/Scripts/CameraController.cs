using UnityEngine;
using System.Collections;

/* CameraController - Responsible for rotating the camera around the ball.
 *  
 * Reference: https://www.youtube.com/watch?v=Ta7v27yySKs
 */

public class CameraController : MonoBehaviour
{
    public GameObject player;

    [Header("Camera Movement Settings")]
    public float currentXRot;
    public float currentYRot;
    public float minYAngle; // Variables for the maximum possible Y rotation.
    public float maxYAngle;
    public float speedX;
    public float speedY;
    public float distance; // Offset from the camera to the ball.

    void Awake ()
    {
        // Hides the cursor during gameplay.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update ()
    {
        // Stores the rotations from the mouse movements, multiplied by the rotation speed specified.
        currentXRot += Input.GetAxis("Mouse X") * speedX;
        currentYRot -= Input.GetAxis("Mouse Y") * speedY;

        // Disallows the player from rotating the camera underneath the ball, or doing a spin around it on the Y axis.
        // Set in the project to a maximum rotation of 89 degrees on the Y axis.
        currentYRot = Mathf.Clamp(currentYRot, minYAngle, maxYAngle);
	}

    void LateUpdate ()
    {
        Vector3 direction = new Vector3(0, 0, -distance); // Specifies the direction vector with the offset included.
        Quaternion rotation = Quaternion.Euler(currentYRot, currentXRot, 0); // Specifies the rotation. As the Z rotation is not useful for us, it's skipped.
        transform.position = player.transform.position + rotation * direction; // Sets the new position of the camera with the rotation.
        transform.LookAt(player.transform); // Makes the camera always center on the ball.
    }
}
