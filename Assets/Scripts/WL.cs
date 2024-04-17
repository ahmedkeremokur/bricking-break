using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WL : MonoBehaviour
{
    //open menu
    //To understand the 'totalBrick = 0' code, read the 'important' section in the Brick script.
    public void Menu()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Menu");
    }

    //Exit Game
    public void DoExitGame()
    {
        Application.Quit();
    }

    //Open Level Selection Scene
    public void LevelSelector()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");
    }

}
