using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// LoadLevel - Loads a chosen level on the Main Menu. Used by the buttons.

public class LoadLevel : MonoBehaviour
{
	public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
