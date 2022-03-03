using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* TimeText - Updates the time on the HUD canvas.
 * Triggers a gameOver condition if the player failed to reach the end during the given time limit.
 */

public class TimeText : MonoBehaviour
{
    public float timeLimit;
    private TextMeshProUGUI text;

    [SerializeField]
    private Canvas gameOver;

	void Start ()
    {
        text = GetComponent<TextMeshProUGUI>();
	}
	
	void Update ()
    {
        // Checks the time basing on the time elapsed since loading the scene.
        float time = timeLimit - Time.timeSinceLevelLoad;

        // Triggers a lose condition if the time limit has passed.
        if (time <= 0.1f)
        {
            gameOver.GetComponent<GameOver>().ChangeGameToOver(3);
        }

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;

        string minutesText, secondsText;

        if (minutes < 10)
        {
            minutesText = "0" + minutes.ToString();
        }

        else
        {
            minutesText = minutes.ToString();
        }

        if (seconds < 10)
        {
            secondsText = "0" + seconds.ToString();
        }

        else
        {
            secondsText = seconds.ToString();
        }

        text.SetText(minutesText + ":" + secondsText);
	}
}
