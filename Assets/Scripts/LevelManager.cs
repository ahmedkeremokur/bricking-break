using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelManager : MonoBehaviour
{




    // --------Level Kilit Sistemi---------

    public List<Button> levelButton;
    public bool delete;


    private void Start()
    {

        if (delete)
            PlayerPrefs.DeleteAll();

        int saveIndex = PlayerPrefs.GetInt("SaveIndex");

        for (int i = 0; i < levelButton.Count; i++)
        {
            if (i <= saveIndex)
            {
                levelButton[i].interactable = true;
            }

            else
            {
                levelButton[i].interactable = false;
            }
        }


    }


 
    
    
    public void LevelSelect()
    {
        
        int level = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        Brick.totalBrick = 0;
        SceneManager.LoadScene(level);
        Cursor.visible = false;
    }
    
    
    
    
    
    
    
    
    
    public void lvl1()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Level1");
        Cursor.visible = false;
        
    }

    public void lvl2()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Level2");
        Cursor.visible = false;
    }

    public void lvl3()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game3");
        Cursor.visible = false;
    }

    public void lvl4()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game4");
        Cursor.visible = false;
    }

    public void lvl5()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game5");
        Cursor.visible = false;
    }

    public void lvl6()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game6");
        Cursor.visible = false;
    }

    public void lvl7()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game7");
        Cursor.visible = false;
    }

    public void lvl8()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game8");
        Cursor.visible = false;
    }

    public void lvl9()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game9");
        Cursor.visible = false;
    }

    public void lvl10()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Game10");
        Cursor.visible = false;
    }

    public void mainMenu()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }

}
