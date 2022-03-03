using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlaySound - Plays a sound when a button is pressed. Function solely for the buttons on the Main Menu.

public class PlaySound : MonoBehaviour
{
	public void Play()
    {
        GetComponent<AudioSource>().Play();
    }
}
