using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Brick : MonoBehaviour    
{
    public static int totalBrick;
    public Sprite[] brickSprite;
    private int maxCollision;
    private int collisionNo;
    public AudioClip collideAudio, destroyAudio, winAudio;
    public string levelIndex;

    public static LevelManager levelManager;

    public int buildIndex;

    // Start is called before the first frame update
    void Start()
    {
        maxCollision = brickSprite.Length;
        totalBrick++;

        //Lvl kilit sistemi

        //buildIndex = SceneManager.GetActiveScene().buildIndex;
        //Text levelText = GameObject.Find("LevelText").GetComponent<Text>();
        //levelText.text = "Level_" + buildIndex.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            totalBrick = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ball"))
        {
            collisionNo++;
            if (collisionNo >= maxCollision)
            {
                Debug.Log(totalBrick);
                totalBrick--;
                if (totalBrick <= 0)
                {

                    int saveIndex = PlayerPrefs.GetInt("SaveIndex");

                    if(buildIndex > saveIndex)
                    {
                        PlayerPrefs.SetInt("SaveIndex", buildIndex);
                    }

                    //SceneManager.LoadScene("Levels");
                    //GameObject.FindObjectOfType<Controller>().GetComponent<Controller> (). NextScene();         //No more brick so next stage

                    gameObject.AddComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(winAudio, transform.position);




                }

                    //Brick Destroy

                gameObject.AddComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
                
                
                Destroy(this.gameObject);
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = brickSprite[collisionNo];                                 //Ball-Brick collided but the brick didn't destroy

                gameObject.AddComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(collideAudio, transform.position);
            }
        }
    }

    

}
