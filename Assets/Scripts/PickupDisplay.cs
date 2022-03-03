using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* PickupDisplay - Displays the amount of picked up pickups on the HUD canvas,
 * and also flashes the text field in red when the player picks up a
 * dontPickUp.
 */

public class PickupDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Canvas gameOver;

    private int pickupsCollected;
    private TextMeshProUGUI text;

    void Start ()
    {
        text = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Gets the amount of pickups from the player.
        pickupsCollected = player.GetComponent<PlayerController>().GetPickUps();
        // Updates the text on the HUD canvas.
        text.SetText(pickupsCollected.ToString());

        // Triggers a gameOver end if the player has less than 0 pickups.
        if (pickupsCollected < 0)
        {
            gameOver.GetComponent<GameOver>().ChangeGameToOver(1);
        }
	}

    // This function is invoked if the player loses one of his lives.
    public void StartFlashing()
    {
        StartCoroutine(Flash());
    }

    // This function changes the colour of the text field quickly to red and white to give it a flash effect.
    IEnumerator Flash()
    {
        for (int i = 0; i < 4; i++)
        {
            text.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
            text.color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(0.1f);
        }
        text.color = new Color32(255, 255, 255, 255);
    }
}
