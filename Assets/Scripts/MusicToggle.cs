using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* MusicToggle - Changes the AudioManager's variables depending on user's choice in the Options menu. 
 * Used by the toggles.
 */

public class MusicToggle : MonoBehaviour
{
    public void ChangeMusicStatus()
    {
        if (AudioManager.music)
        {
            AudioManager.music = false;
        }

        else if (!AudioManager.music)
        {
            AudioManager.music = true;
        }
    }
}
