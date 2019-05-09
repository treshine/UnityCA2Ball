using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    bool started;
    bool gameOver;
    Rigidbody2D rb; // set to Kinematic type in Unity
    public float upForce; // 200 works well
    public float rotation;// ball rotation while moving

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
                GameManager.instance.GameStart (); // start the game
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
    
    void OnCollisionEnter2D(Collision2D col){
        gameOver = true;
        GameManager.instance.GameOver ();
        GetComponent<Animator> ().Play ("ball"); //play ball dead state
    }
    
    void OnTriggerEnter2D(Collider2D col){
        
        // player hit Pipe trigger so gameover
        if (col.gameObject.tag == "Pipe" && !gameOver) {
            gameOver = true;
            GameManager.instance.GameOver ();

            GetComponent<Animator> ().Play ("ball");//play ball dead state
        }
        // player hit ScoreChecker passing through pipes so increase score
        if (col.gameObject.tag == "ScoreChecker" && !gameOver) {
            ScoreManager.instance.IncrementScore ();
        }
    }
}
