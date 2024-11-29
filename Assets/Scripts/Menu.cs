using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // function to start the game
    public void StartGame()
    {
        // load the first scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_1");
    }
}
