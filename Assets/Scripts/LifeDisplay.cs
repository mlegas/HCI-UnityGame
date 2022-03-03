using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// LifeDisplay - Displays the lives on the HUD canvas.

public class LifeDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject player; // Takes the amount of lives from the player gameObject.
    private TextMeshProUGUI text; // Takes the text field from the HUD canvas.

    // Use this for initialization
    void Start ()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.SetText(player.GetComponent<LifeController>().lives.ToString());
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.SetText(player.GetComponent<LifeController>().lives.ToString());
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
