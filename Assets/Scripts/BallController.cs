using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    bool started;
    bool gameOver;
    Rigidbody2D rb; // set to Kinematic type in Unity
    public float upForce; // 200 works well
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> (); 
        started = false; 
        gameOver = false;
    }

    // Update is called once per frame
    void Update () {
        // Game not started
        if (!started) {
            /* GetMouseButton works for single taps as well
               Input.GetMouseButtonDown (0) is the first touch */
            if (Input.GetMouseButtonDown (0)) {
                started = true;
                rb.isKinematic = false; // ball is not moving yet
                //GameManager.instance.GameStart ();
            }
        } 
        // Game is started
        else if(started && !gameOver){
            transform.Rotate (0, 0, rotation);
            // Game is started and user is tapping
            if (Input.GetMouseButtonDown (0)) {
                // set initial ball velocity to 0 to allow enough upward motion
                rb.velocity = Vector2.zero;
                // Tap will only add force to y direction 
                rb.AddForce (new Vector2 (0, upForce));
            }
        }
    }
}
