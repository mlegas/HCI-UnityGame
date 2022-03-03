using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SoundsToggle - Changes the AudioManager's variables depending on user's choice in the Options menu. 
 * Used by the toggles.
 */

public class SoundsToggle : MonoBehaviour
{
    public void ChangeSoundsStatus()
    {
        if (AudioManager.sounds)
        {
            AudioManager.sounds = false;
        }

        else if (!AudioManager.sounds)
        {
            AudioManager.sounds = true;
        }
    }
}
