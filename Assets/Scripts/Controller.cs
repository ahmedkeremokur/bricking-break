using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject panel;

    int gameState = 1;          // 1: game, 2: pause, 3:options
    //public AudioSource theme;


    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))             // Esc to Pause menu or game
        {
            //if (gameIsPaused)
            if (gameState == 2)
            {
                Resume();                                  //to pause menu
            }
            else if (gameState == 1)
            {                                               // we can do it else if pause and else if options with int gameState
                Pause();                                   //to game
            }

            else if (gameState == 3)
            {
                Pause();
            }
        }

    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        panel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        gameState = 1;
        Cursor.visible = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        gameState = 2;
        Cursor.visible = true;
    }
    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        panel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        gameState = 3;
        Cursor.visible = true;

    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        gameState = 1;
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }


    public void DoExitGame()
    {
        Application.Quit();
    }
    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }
    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void SetMusic(bool isMusic)
    {
        //theme.mute = !isMusic;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
