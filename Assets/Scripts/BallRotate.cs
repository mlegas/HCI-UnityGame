using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// BallRotate - Rotates the ball in the Main Menu around its Y axis.

public class BallRotate : MonoBehaviour
{
    public float speed;

	void Update ()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0, Space.Self);
	}
}
