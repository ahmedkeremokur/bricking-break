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
        totalBrick++;   //Green Bricks: +1, Yellow Bricks: +2, Red Bricks: +3
    }

    // Update is called once per frame
    void Update()
    {
        //It is another cheat. After pressing 'A', it opens the new scene when the ball-brick collision occurs. 
        if (Input.GetKeyDown(KeyCode.A))
        {
            totalBrick = 1;
        }
    }

    //Collision number goes 1, 2, 3.... until it will equals to totalBrick
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("Ball"))
        {
            collisionNo++;
            if (collisionNo >= maxCollision)
            {
                //---------------------------------IMPORTANT!!.--------------------------------------

                //If you lose or return to the menu, the scene is refreshed in any way other than winning the level,
                //the remaining totalBrick count is added to the new one. This prevents the game from ending even if there are no bricks left in the scene.
                //Therefore, we need to reset the totalBrick count.

                Debug.Log(totalBrick);
                totalBrick--;
                if (totalBrick <= 0)
                {
                    //Unlock new level (PlayerPrefs)
                    int saveIndex = PlayerPrefs.GetInt("SaveIndex");

                    if(buildIndex > saveIndex)
                    {
                        PlayerPrefs.SetInt("SaveIndex", buildIndex);
                    }

                    //Audio
                    gameObject.AddComponent<AudioSource>();
                    AudioSource.PlayClipAtPoint(winAudio, transform.position);

                }

                    //Brick Destroy
                gameObject.AddComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
                              
                Destroy(this.gameObject);
            }

            else
            //Ball-Brick collided but the brick didn't destroy
            {
                GetComponent<SpriteRenderer>().sprite = brickSprite[collisionNo];

                gameObject.AddComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(collideAudio, transform.position);
            }
        }
    }

    

}
