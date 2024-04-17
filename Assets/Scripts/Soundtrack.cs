using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{

    static bool soundtrack;
    // Start is called before the first frame update
    void Start()
    {
        //The background music starts playing in the menu scene.
        //However, when returning to the menu from within the game, we need to check to prevent additional music from playing on top of it.
        if (!soundtrack)
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            soundtrack = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
