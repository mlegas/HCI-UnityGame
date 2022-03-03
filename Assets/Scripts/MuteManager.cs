using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* MuteManager - Mutes the music and/or sounds in the levels depending on user's choice in the Options menu,
 *  by reading the variables from the AudioManager.
 */

public class MuteManager : MonoBehaviour
{
    /* As this script is both used in the Main Menu and the levels,
     * the script has to check if the music/sounds have been muted
     * in its Update() function. Therefore, to stop it from setting
     * the mute setting on each frame, a boolean check has to be made
     * if the music/sounds have been already muted.
     */

    private bool onceMusicMuted = false;
    private bool onceMusicUnmuted = false;
    private bool onceSoundsMuted = false;
    private bool onceSoundsUnmuted = false;

    void Update ()
    {
        if (AudioManager.music && !onceMusicUnmuted)
        {
            // If the music has been unmuted, it means it can be muted now.
            onceMusicUnmuted = true;
            onceMusicMuted = false;

            // Go through each music gameObject child and unmute it.
            foreach (Transform child in transform)
            {
                if (child.tag == "Music")
                {
                    child.GetComponent<AudioSource>().mute = false;
                }
            }
        }

        else if (!AudioManager.music && !onceMusicMuted)
        {
            // If the music has been muted, it means it can be unmuted now.
            onceMusicMuted = true;
            onceMusicUnmuted = false;

            // Go through each music gameObject child and mute it.
            foreach (Transform child in transform)
            {
                if (child.tag == "Music")
                {
                    child.GetComponent<AudioSource>().mute = true;
                }
            }
        }

        if (AudioManager.sounds && !onceSoundsUnmuted)
        {
            // If the sounds have been unmuted, it means they can be muted now.
            onceSoundsUnmuted = true;
            onceSoundsMuted = false;

            // Go through each sound gameObject child and unmute it.
            foreach (Transform child in transform)
            {
                if (child.tag == "Sound")
                {
                    child.GetComponent<AudioSource>().mute = false;
                }
            }
        }

        else if (!AudioManager.sounds && !onceSoundsMuted)
        {
            // If the sounds have been muted, it means they can be unmuted now.
            onceSoundsMuted = true;
            onceSoundsUnmuted = false;
            
            // Go through each sound gameObject child and unmute it.
            foreach (Transform child in transform)
            {
                if (child.tag == "Sound")
                {
                    child.GetComponent<AudioSource>().mute = true;
                }
            }
        }
    }
}
