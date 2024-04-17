using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelSystem : MonoBehaviour
{
    public float whenWeAreHigh = 10f;  //speed of the pass object, I was listening this song while I was writing this..
    public int buildIndex = 0;
    public string saveIndex;

    private void Start()
    {
        //-----Lvl Locking System--------

        buildIndex = SceneManager.GetActiveScene().buildIndex;
        Text levelText = GameObject.Find("levelText").GetComponent<Text>();
        levelText.text = "Level_" + buildIndex.ToString();
    }
    
    private void Update()
    {
        if (Brick.totalBrick <= 0)
        {
            NextLevel();
        }

        //Actually it is a cheat
        if (Input.GetKeyDown(KeyCode.O))    //It is not zero
        {
            NextLevel();
        }
    }

    //Next Level System. Open the next scene based on the scene number and unlock the new level.
    public void NextLevel()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        if (buildIndex > saveIndex)
        {
            PlayerPrefs.SetInt("SaveIndex", buildIndex);
        }
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, whenWeAreHigh);

        GameObject.FindObjectOfType<Controller>().GetComponent<Controller>().NextScene();
    }

    //There are 2 object in the scene with just colliders. When there is no brick in the scene the are colliding and next lvl..
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Gate"))
        {
            Debug.Log("Eminem - Without Me");   //Check the collision


            NextLevel();
        }
    }

}
