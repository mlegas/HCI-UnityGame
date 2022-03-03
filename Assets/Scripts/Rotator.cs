using UnityEngine;
using System.Collections;

// Rotator - Rotates the pickUps.

public class Rotator : MonoBehaviour 
{
	void Update () 
	{
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
