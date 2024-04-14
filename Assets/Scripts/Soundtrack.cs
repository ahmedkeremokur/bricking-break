using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtrack : MonoBehaviour
{

    static bool soundtrack;
    // Start is called before the first frame update
    void Start()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
