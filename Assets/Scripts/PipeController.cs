using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public float speed; //how fast pipes move
    public float upDownSpeed; // how fast pipes move up and down
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        MovePipe (); // starts moving the pipes
        
        // SwitchUpDown invoked after 0.1 seconds -> repeated every 1 seconds
        InvokeRepeating ("SwitchUpDown", 0.1f, 1f); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void MovePipe()
    { 
        // -speed will move pipes toward player
        rb.velocity = new Vector2 (-speed, upDownSpeed);
    }
    void SwitchUpDown(){
        upDownSpeed = -upDownSpeed;
        rb.velocity = new Vector2 (speed, upDownSpeed);
    }
    
    // whenever pipe goes through a collider
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "PipeDestroyer") {
            Destroy (gameObject);
        }
    }
}
