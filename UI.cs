/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script controls the operation of the UI.
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the score update, victory and defeat panel show, and restart.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Attach the script to the Clicker_UI object                                  [for Version 1]
 *      -   Disable the Panel object inside Clicker_UI                                  [for Version 1]
 *      -   In the UI component, link the corresponding UI elements to the
 *          corresponding property/field:
 *              - Score Text (should be the Score inside Clicker_UI)
 *              - Panel (should be the disabled Panel inside Clicker_UI)
 *              - Panel Score Text (should be the Total_Score inside the disabled Panel)
 *              - Defeat Text (should be the Defeat_Header inside the disabled Panel)
 *              - Victory Text (should be the Victory_Header inside the disabled Panel) [for Version 1]
 *      -   Specify that the OnClickRestart() method would be executed when the 
 *          Restart Button is clicked
 *              Clicker_UI -> Panel -> Button_Restart                                   [for Version 1]
 *      -   Ensure that an Event System object is present for the UI to work            [for Version 1]
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to be able to work with the UI

public class UI : MonoBehaviour
{
    static UI singleton;

    // links to the different UI elements
    public Text scoreText;         
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
