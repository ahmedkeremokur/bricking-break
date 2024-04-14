using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WL : MonoBehaviour
{

    public void Menu()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Menu");

    }

    public void DoExitGame()
    {

        Application.Quit();

    }


    public void LevelSelector()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");

    }

}
