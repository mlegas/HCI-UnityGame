using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// StarDisplay - Displays and updates the stars on the win canvas.

public class StarDisplay : MonoBehaviour {

    public bool levelFinished; // Makes sure the level has been finished before checking the progress made by the player.

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject pickupsOnScene; // Takes the amount of all good pickups on the level.

    private bool doOnce; // Ensures that the stars are only updated once at the end.
    private Scene scene;

    void Awake()
    {
        doOnce = false;

        scene = SceneManager.GetActiveScene(); // Takes the current scene name to know which stars to update.
    }

	// Update is called once per frame
	void Update ()
    {
        // Updates the first 1-3 stars if Level1 has been finished.
		if (levelFinished && !doOnce && scene.name == "Level1")
        {
            doOnce = true;
            int pickups = player.GetComponent<PlayerController>().GetPickUps();
            int pickupsInWorld = pickupsOnScene.transform.childCount;

            // If the player picked up all good pickups on the level and missed all bad ones, award 3 stars.
            if (pickups == pickupsInWorld)
            {
                // Change the colour of the stars on the win screen.
                transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(1).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(2).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                
                // Update the globally stored stars.
                if (!StarManager.star1)
                {
                    StarManager.star1 = true;
                }

                if (!StarManager.star2)
                {
                    StarManager.star2 = true;
                }

                if (!StarManager.star3)
                {
                    StarManager.star3 = true;
                }

            }

            // If the amount of pickups the player holds is bigger than half of the good pickups located at the start of the level, award 2 stars.
            else if (pickups > (pickupsInWorld / 2))
            {
                // Change the colour of the stars on the win screen.
                transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(1).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);

                if (!StarManager.star1)
                {
                    StarManager.star1 = true;
                }

                if (!StarManager.star2)
                {
                    StarManager.star2 = true;
                }
            }

            // Else if both of these conditions are untrue, award 1 star. Speedrunning grade.
            else
            {
                // Change the colour of the stars on the win screen.
                transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);

                if (!StarManager.star1)
                {
                    StarManager.star1 = true;
                }
            }
        }

        // Updates the first 4-6 stars if Level2 has been finished.
        if (levelFinished && !doOnce && scene.name == "Level2")
        {
            doOnce = true;
            int pickups = player.GetComponent<PlayerController>().GetPickUps();
            int pickupsInWorld = pickupsOnScene.transform.childCount;

            // If the player picked up all good pickups on the level and missed all bad ones, award 3 stars.
            if (pickups == pickupsInWorld)
            {
                // Change the colour of the stars on the win screen.
                transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(1).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(2).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);

                if (!StarManager.star4)
                {
                    StarManager.star4 = true;
                }

                if (!StarManager.star5)
                {
                    StarManager.star5 = true;
                }

                if (!StarManager.star6)
                {
                    StarManager.star6 = true;
                }

            }

            // If the amount of pickups the player holds is bigger than half of the good pickups located at the start of the level, award 2 stars.
            else if (pickups > (pickupsInWorld / 2))
            {
                // Change the colour of the stars on the win screen.
                transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(1).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);

                if (!StarManager.star4)
                {
                    StarManager.star4 = true;
                }

                if (!StarManager.star5)
                {
                    StarManager.star5 = true;
                }
            }

            // Else if both of these conditions are untrue, award 1 star. Speedrunning grade.
            else
            {
                // Change the colour of the stars on the win screen.
                transform.GetChild(0).GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);

                if (!StarManager.star4)
                {
                    StarManager.star4 = true;
                }
            }
        }
    }
}
