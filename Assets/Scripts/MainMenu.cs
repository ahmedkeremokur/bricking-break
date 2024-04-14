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


    public void LoadLevel()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");
    }

    public void DoExitGame()
    {
        Application.Quit();
    }


    public void NewGame()
    {
        gameName.SetActive(false);
        newGameMenu.SetActive(true);
    }


    public void No()
    {
        gameName.SetActive(true);
        newGameMenu.SetActive(false);
    }

    public void Yes()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Levels");
        Cursor.visible = true;

        PlayerPrefs.DeleteAll();
    }


}
