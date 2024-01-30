/* ****************************************************************************************************
 * AUTHOR: 
 *      Adrian Josele G. Quional
 * ====================================================================================================
 * SCRIPT DESCRIPTION: 
 *      This script implements the operation (movement and catching) of the squares.
 * ====================================================================================================
 * VERSIONS:
 *      -   Version 1:  Implemented the random movement and catch mechanics.
 * ====================================================================================================
 * HOW TO USE THE SCRIPT:
 *      -   Create the target and trap squares                                          [for Version 1]
 *      -   Make sure that there is a Box Collider 2D component attached to the squares [for Version 1]
 *      -   Attach the script to the target and trap square objects                     [for Version 1]
 *      -   Specify the correct property settings per square, specifically:             
 *              - Move Step
 *              - Is Trap
 *              - Speed Factor
 *              - Scale Factor
 *              - Catch Count                                                           [for Version 1]
 * ****************************************************************************************************/

// libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Vector2 targetPosition;  // where the squares would move to
    public float moveStep;          // step length of the squares' movements

    public bool isTrap;             // used to distinguish which square is a trap

    public float speedFactor;       // how fast the speed of the square would change after clicking
    public float scaleFactor;       // how small the square would be reduced to when clicked

    public int catchCount;          // number of possible clicks on a square before it's removed from the game

    // at the beginning of the game, randomize the position of the squares right away
    void Start()
    {
        // if the square is not a trap, then put it in the list of squares to be clicked by the player
        if (isTrap == false)
        {
            Player.squares.Add(this);
        }

        // move the square to a random position
        targetPosition = GetRandomPoint();
    }

    // repeatedly move the square in a random position
    void Update()
    {
        // moving the square towards a random position
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveStep * Time.deltaTime);

        // if the chosen random position is the same position as before, get another random position
        if((Vector2)transform.position == targetPosition)
        {
            targetPosition = GetRandomPoint();
        }
    }

    // method to get a random position for the square
    Vector2 GetRandomPoint()
    {
        Vector2 randomVector = new Vector2();

        randomVector.x = Random.Range(-6, 6);   // gets a random x-coordinate within the length of the game screen
        randomVector.y = Random.Range(-3, 3);   // gets a random y-coordinate within the height of the game screen

        return randomVector;    // returns the x- and y-coordinates as a 2D vector
    }

    // method to execute whenever a square (that is not a trap) is clicked
    void Catch()
    {
        Player.score++;     // increment the Player's score

        catchCount--;       // number of possible clicks decreases when a non-trap square is clicked

        // if the number of possible clicks is zero,  remove the square from the game
        if (catchCount == 0)
        {
            Player.squares.Remove(this);    // removes the square from the list of non-trap squares
            Destroy(gameObject);            // destroys the object that the script is attached to
        }

        // else, continuously move the square and reduce its size until it's destroyed eventually
        else
        {
            moveStep += speedFactor;
            transform.localScale = (Vector2)transform.localScale - new Vector2(scaleFactor, scaleFactor);
            transform.position = GetRandomPoint();
        }
    }

    // method to execute when left mouse button is pressed (or when click event happens) 
    void OnMouseDown()
    {
        // if the square that has been clicked is a trap, show a defeat message
        if (isTrap)
        {
            Player.Defeat();
        }

        // else, continue play the game (per mechanics of clicking a non-trap square)
        else
        {
            Catch();
        }
    }
}
