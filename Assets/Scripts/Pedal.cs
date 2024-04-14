using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//class UnityEngine.Camera

public class Pedal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Ball ball1Instance = FindObjectOfType<Ball>;  
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 farePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        transform.position = new Vector3 (Mathf.Clamp(farePos.x,-10,10), transform.position.y, transform.position.z);   
        
    }
}
