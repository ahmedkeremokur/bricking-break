using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallScene : MonoBehaviour
{
   
    void lvlMenu()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");
    }

    void mainMenu()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Menu");
    }




}
