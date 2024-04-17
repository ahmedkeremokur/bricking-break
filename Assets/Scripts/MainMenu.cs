using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject gameName;
    public GameObject newGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameName.SetActive(true);
        newGameMenu.SetActive(false);
    }

    //Open the level selection scene
    public void LoadLevel()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");
    }

    //Exit Game
    public void DoExitGame()
    {
        Application.Quit();
    }

    //Open new game objects, close some menu objects
    public void NewGame()
    {
        gameName.SetActive(false);
        newGameMenu.SetActive(true);
    }

    //Asks if you sure to delete the progression
    public void No()
    {
        gameName.SetActive(true);
        newGameMenu.SetActive(false);
    }

    //if you say yes all of the progression will be lost. And open the level selection scene
    public void Yes()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");
        Cursor.visible = true;

        PlayerPrefs.DeleteAll();
    }

}
