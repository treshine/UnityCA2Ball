using System.Collections;
using System.Collections.Generic;
using GooglePlayGames.Native.Cwrapper;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Login()
    {
        // authenticate user:
        Social.localUser.Authenticate((bool success) => {
        });
    }

    public void ShowAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            Login();
        }
    }

    public void CheckAchievements()
    {
        if(ScoreManager.instance.score > 4)
             Social.ReportProgress(Achievements.achievement_beginner, 100f, (bool success) => {});
        if(ScoreManager.instance.score > 9)
            Social.ReportProgress(Achievements.achievement_intermediate, 100f, (bool success) => {});
        if(ScoreManager.instance.score > 14)
            Social.ReportProgress(Achievements.achievement_great_player, 100f, (bool success) => {});
        if(ScoreManager.instance.score > 19)
            Social.ReportProgress(Achievements.achievement_expert_player, 100f, (bool success) => {});
        if(ScoreManager.instance.score > 49)
            Social.ReportProgress(Achievements.achievement_super_pro, 100f, (bool success) => {});
        
    }

}
