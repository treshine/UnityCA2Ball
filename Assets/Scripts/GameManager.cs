using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    bool gameOver;
    
    void Awake(){
        // GameManager need to continue existing while Game is running
        DontDestroyOnLoad (this.gameObject);

        if (instance == null) {
            instance = this;
        } 
        // GameManager instance available already so destroy 
        else {
            Destroy (this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            AchievementManager.instance.CheckAchievements();
        }
    }
    
    public void GameStart(){
        UIManager.instance.GameStart ();
        // Start spawning pipes
        GameObject.Find ("PipeSpawner").GetComponent<PipeSpawner> ().StartSpawingPipes ();

    }

   
    
    public void GameOver(){
        gameOver = false;
        GameObject.Find ("PipeSpawner").GetComponent<PipeSpawner> ().StopSpawningPipes ();
        ScoreManager.instance.StopScore ();
        LeaderboardManager.instance.AddScoreToLeaderboard();
        UIManager.instance.GameOver ();
        UnityAdManager.instance.ShowAd ();
    }
}
