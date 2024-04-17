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

            //if game state = game
            else if (gameState == 1)
            {                                               // we can do it else if pause and else if options with int gameState
                Pause();                                   //to game
            }

            //if game state = options
            else if (gameState == 3)
            {
                Pause();
            }
        }

    }

    //make the game state = game. Close pause menu, cursor invisible, time goes on..
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

    //make the game state = pause. Open pause menu, cursor visible, time stops..
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

    //make the game state = options. It's just like pause menu but you can manage different settings..
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

    //open menu scene
    public void MainMenu()
    {
        Time.timeScale = 1f;
        gameState = 1;
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }

    //Exit Game
    public void DoExitGame()
    {
        Application.Quit();
    }
    //Graph Quality. Doesn't necessary
    public void SetQuality(int qual)
    {
        QualitySettings.SetQualityLevel(qual);
    }

    //Full Screen
    public void SetFullScreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    //Open - Close Music. Not working for now..
    public void SetMusic(bool isMusic)
    {
        //theme.mute = !isMusic;
    }

    //Open the next scene based on the scene number
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
