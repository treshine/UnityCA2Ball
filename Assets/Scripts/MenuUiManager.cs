using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiManager : MonoBehaviour
{
    public static MenuUiManager instance;   
    
    private void Awake(){   
     DontDestroyOnLoad (this.gameObject);
        if (instance == null) {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowLeaderbord()
    {
        LeaderboardManager.instance.ShowLeaderboard();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    // Play will load level1 scene when button is tapped
    public void Play()
    {
     SceneManager.LoadScene ("level1");
    }


    


}
