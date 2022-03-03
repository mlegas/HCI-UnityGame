using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* MainMenuLevel1Stars - Checks the progress made by the player on Level2 by reading StarManager's variables 
 * and lits up the stars on the Main Menu scene by raising their alphas. 
 */

public class MainMenuLevel2Stars : MonoBehaviour {

    void Awake ()
    {
        if (StarManager.star4)
        {
            transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
        }

        if (StarManager.star5)
        {
            transform.GetChild(1).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
        }

        if (StarManager.star6)
        {
            transform.GetChild(2).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
        }
    }
}
