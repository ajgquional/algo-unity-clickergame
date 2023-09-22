/* **************************************************
 * Author: 
 *      Adrian Josele G. Quional
 * 
 * Program description: 
 *      This program controls the operation of the 
 *      UI in the simple Clicker game.
 * 
 * How to use the script:
 *      Attach the script to the Clicker_UI object.
 * **************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to be able to work with the UI

public class UI : MonoBehaviour
{
    // linking to different UI elements
    public Text scoreText;

    static UI singleton;         
    public GameObject panel;
    public Text panelScoreText;
    public Text defeatText;
    public Text victoryText;

    // singleton makes sure that the UI is globally accessible and only instantiated once in the game
    void Awake()
    {
        singleton = this;
    }

    // always updates the score text
    void Update()
    {
        scoreText.text = Player.score.ToString();
    }

    // method to execute if the Player wins the game
    public static void ShowVictoryPanel()
    {
        singleton.panel.SetActive(true);                            // shows the panel
        singleton.victoryText.gameObject.SetActive(true);           // shows the victory text in the panel
        singleton.panelScoreText.text = Player.score.ToString();    // shows the score in the panel
    }

    // method to execute if the Player loses the game
    public static void ShowDefeatPanel()
    {
        singleton.panel.SetActive(true);                            // shows the panel
        singleton.defeatText.gameObject.SetActive(true);            // shows the defeat text in the panel
        singleton.panelScoreText.text = Player.score.ToString();    // shows the score  in the panel
    }

    // if the Player clicked the "Play" button, restart the game
    public void OnClickRestart()
    {
        Player.Restart();
    }
}
