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



    // Start is called before the first frame update
    void Start()
    {
        pedal = GameObject.FindObjectOfType<Pedal>().gameObject;
        outlineAudioSource = GetComponent<AudioSource>();   //Get audiosource component for outlines
        if (outlineAudioSource == null)
        {
            outlineAudioSource = gameObject.AddComponent<AudioSource>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            {
            Time.timeScale = 0;
            }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 1;
        }
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0f); //there was a bug that cause the ball moving at z axis but I don't know why. That's for locking it.
        if (!gameStarted)
        {
            transform.position = new Vector3(pedal.transform.position.x, transform.position.y, transform.position.z);   //make the ball move with the bar before the game starts
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelocity, ballVelocity);     //first movement
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        //if (collision.gameObject.name == "Right")
        //{
         //   ballRigidBody.velocity = new Vector2(-ballVelocity, ballRigidBody.velocity.y);
        //}

        //if (collision.gameObject.name == "Left")
        //{
         //   ballRigidBody.velocity = new Vector2(ballVelocity, ballRigidBody.velocity.y);
        //}

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

    public void stuck()
    {
        transform.position = new Vector3(pedal.transform.position.x, pedal.transform.position.y + 1f, 0f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 8f);
    }


}
