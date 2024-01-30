/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls the operation of the player
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the basic player mechanics: initialization of a list of squares,
 *                      checking of victory and defeat scenarios, and restarting of level.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the Main Camera object                                 [for Version 1]
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // needed for restarting the scene

public class Player : MonoBehaviour
{
    public static int score = 0;            // initializing the square of the player

    public static List<Square> squares;     // declaring a list of non-trap squares to be clicked by the player

    // creates a list of squares before the game even begins
    void Awake()
    {
        squares = new List<Square>();     
    }

    // continuously check if the list of squares is empty; if so, show a victory message
    void Update()
    {
        if (squares.Count == 0)
        {
            Victory();
        }
    }

    // once the player is defeated, show the defeat message
    public static void Defeat()
    {
        UI.ShowDefeatPanel();
    }

    // if the player won, show the victory message
    public static void Victory()
    {
        UI.ShowVictoryPanel();
    }

    // if the player has chosen to click the "Play" button in the defeat or victory panels, restart the game and reset the score to 0
    public static void Restart()
    {
        score = 0;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
