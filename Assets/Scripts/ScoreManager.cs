using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    
    void Awake(){
        if (instance == null) {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {  
      // initialize score values to 0
      score = 0;
      PlayerPrefs.SetInt ("Score", 0);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void IncrementScore(){
        score++;
    }
    
    public void StopScore(){
		// save current score to Score
        PlayerPrefs.SetInt ("Score", score);

        // if HighScore is already crated
        if (PlayerPrefs.HasKey ("HighScore")) {
            // If Player has beaten HighScore
            if (score > PlayerPrefs.GetInt ("HighScore")) {
                // current score is set as HighScore
                PlayerPrefs.SetInt ("HighScore", score);
            }
        } else {
            // first time HighScore is set
            PlayerPrefs.SetInt ("HighScore", score);
        }

    }
}
