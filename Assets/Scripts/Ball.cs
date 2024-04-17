using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private GameObject pedal;
    private bool gameStarted = false;
    public AudioClip outlineAudio, pedalAudio;
    private AudioSource outlineAudioSource;
    public Rigidbody2D ballRigidBody;
    public float ballVelocity = 7.0f;
    public bool isPaused = false;



    // Start is called before the first frame update
    void Start()
    {
        pedal = GameObject.FindObjectOfType<Pedal>().gameObject;
        isPaused = false;

        //Audio
        outlineAudioSource = GetComponent<AudioSource>();   //Get audiosource component for outlines
        if (outlineAudioSource == null)
        {
            outlineAudioSource = gameObject.AddComponent<AudioSource>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        //-----Pause-----  Keycode: Space
        if (isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                isPaused = false;
            }
        }
        
        
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); //There was a bug causing the ball to move along the z-axis, which is why I locked it.
        if (!gameStarted)
        {
            transform.position = new Vector3(pedal.transform.position.x, transform.position.y, transform.position.z);   //Before the game starts, it synchronizes the ball's movement with the bar.
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelocity, ballVelocity);     //first movement
            }
        }
    }

    //Collisions: Brick, outlines, pedal.   Trigger: Fall Collider
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("Brick"))
        {
            Debug.Log("Collision occured with a brick.");
            ContactPoint2D contactPoint = collision.contacts[0];            
        } 
            
        else if (collision.gameObject.tag.Equals("Outlines"))
        {
            collideOutlines();
        }

        else if (collision.gameObject.tag.Equals("Pedal"))
        {

            AudioSource.PlayClipAtPoint(pedalAudio, transform.position, 0.25f);

        }

    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag.Equals("Fall"))
        {
            fall();
        }
    }

    public void collideOutlines()
    {
        Debug.Log("Collision occured with an outline.");
        GetComponent<AudioSource>().PlayOneShot(outlineAudio,0.25f);
    }


    public void fall()
    {
        Debug.Log("Game Over!!!, You have achieved the Failure");
        SceneManager.LoadScene("Lose");
        Cursor.visible = true;
    }

    //Sometimes the ball only moves along the horizontal axis. For now, I'm leaving a button for the user to fix this
    public void stuck()
    {
        transform.position = new Vector3(pedal.transform.position.x, pedal.transform.position.y + 1f, 0f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 8f);
    }


}
