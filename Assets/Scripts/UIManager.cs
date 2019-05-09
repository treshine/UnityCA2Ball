using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverPanel;
    public GameObject startUi;
    public GameObject gameOverText;
    public Text scoreText;
    public Text highScoreText;
    
    
    //Twitter Share Link
    string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    //Language
    string TWEET_LANGUAGE = "en";
    //Text to post
    string textToDisplay="Hey Guys! Check out my score: ";
    
    
    
    private void Awake(){
        if (instance == null) {
            instance = this;
        }
    }
    
    // Start is called before the first frame update
    public void Start()
    {

    }
 
    // Update is called once per frame 
    public void Update()
    {
        scoreText.text = ScoreManager.instance.score.ToString ();
    }
    
    public void GameStart(){
    	startUi.SetActive (false);
    }
    
    public void GameOver(){
    	gameOverText.SetActive (true);
    	highScoreText.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore");
    	gameOverPanel.SetActive (true);
    }
    
    public void PlayAgain(){  
    	SceneManager.LoadScene ("level1");
    }
    
    public void Menu(){
    	SceneManager.LoadScene ("Menu");
    }
    
    public void ShareScoreOnTwitter () 
    {
        Application.OpenURL (TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay) + ScoreManager.instance.score + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }
}
