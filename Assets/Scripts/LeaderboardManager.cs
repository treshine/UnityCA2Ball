using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager instance;
    
    private void Awake(){

        if (instance == null) {
            instance = this;
        }
    }
    
    
    // Start is called before the first frame update
    public void Start()
    {
        PlayGamesPlatform.Activate();
        Login();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
     // authenticate user:
     Social.localUser.Authenticate((bool success) => {
     // handle success or failure
     
     });
    }

    public void AddScoreToLeaderboard()
    {
        Social.ReportScore(ScoreManager.instance.score, Leaderboard.leaderboard_best_treball_players, 
                            (bool success) => {});
    }
    
    public  void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            //Social.ShowLeaderboardUI();
            
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIleL2kvAIEAIQAA");

        }
        else
        {
            Login();
        }
    }
}
