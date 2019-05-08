using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// instantiates pipes in random position
public class PipeSpawner : MonoBehaviour
{
    
    public float maxYpos;
    public float SpawnTime;
    public GameObject pipe;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    
    void SpawnPipe(){
        // instantiate the pipe at a random y position in set range
        Instantiate (pipe, new Vector3 (transform.position.x, Random.Range (-maxYpos, maxYpos), 0), Quaternion.identity);
    }
    
    public void StartSpawingPipes(){
        InvokeRepeating ("SpawnPipe", 0.2f, SpawnTime);
    }
  
    public void StopSpawningPipes(){
        CancelInvoke ("SpawnPipe");
    }

    
    
}
