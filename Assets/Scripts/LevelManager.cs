using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelManager : MonoBehaviour
{

    // --------Level Locking System---------

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

    //The code for all level buttons
    public void LevelSelect()
    {        
        int level = int.Parse(EventSystem.current.currentSelectedGameObject.name);

        Brick.totalBrick = 0;
        SceneManager.LoadScene(level);
        Cursor.visible = false;
    }    

    //Menu Button
    public void MainMenu()
    {
        Brick.totalBrick = 0;
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }
}
