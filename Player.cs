/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program controls the operation of the 
 *      player in the simple Clicker game.
 * 
 * How to use the script:
 *      Attach the script to the Main Camera object.
 * **************************************************/

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
