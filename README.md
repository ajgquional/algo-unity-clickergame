# Simple Unity Clicker Game

<p align='center'>
  <img src="https://github.com/ajgquional/algo-unity-clickergame/blob/b78c4d22a742a66f72523e9be247fa999bcba689/Algo-Unity-Simple-Clicker-Game.gif" width=600 height=400/>
</p>

## About the game

In this simple clicker game, the objective is to click the non-trap square (black) to gain points. Every time a non-trap square is clicked, the player's score would increase but, as a consequence, the square gets smaller and moves faster. Once the non-trap square is clicked three times, the game is won. On the other hand, if the trap square (red) is clicked, the game is automatically over.

This game is created as an introduction to 2D game development in Unity. As such, the mechanics of the game is very simple. It is envisioned for this game to be improved to include more trap and non-trap squares, a timer, and, probably, levels.

## About the repository and scripts

This repository contains all the scripts needed to complete the simple clicker game. 
* <a href="https://github.com/ajgquional/algo-unity-clickergame/blob/main/Square.cs">Square.cs</a> - details the operation of the squares (random spawn, movement)
* <a href="https://github.com/ajgquional/algo-unity-clickergame/blob/main/Player.cs">Player.cs</a> - details the operation of the player (defeat and victory mechanics, restart)
* <a href="https://github.com/ajgquional/algo-unity-clickergame/blob/main/UI.cs">UI.cs</a> - details the operation of the UI (display of appropriate UI elements according to game status)

## General instructions on using the scripts
1. Setup the game as discussed in the class or as detailed in the handbook.
2. Create scripts in a Code folder under Assets.
3. Copy the program from this repository to the corresponding script created.
4. Attach the scripts to the corresponding game objects (Square.cs to the two squares, Player.cs to the Main Camera, and UI.cs to the Clicker_UI game object).

## Relevant links
* Complete handbook/lesson slides (c/o Algorithmics): https://docs.google.com/presentation/d/1g2Nl-FZZD4h7XSn91sR29hPDEImYyYC06LkRD_7QAvs/edit#slide=id.p1
* Completed activity (c/o Algorithmics): https://drive.google.com/file/d/1O7fVnyvl3f0Xdqcrkb3kYVRlXHVGln4W/view
* Published game: https://algo-clicker-adrian.netlify.app/
