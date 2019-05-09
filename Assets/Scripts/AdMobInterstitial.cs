using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using UnityEngine.EventSystems;


public class AdMobInterstitial : MonoBehaviour
{
    public string AppID;
    public string InterstitialAdID;
    public string level;

    private InterstitialAd interstitialAd;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(AppID);
        interstitialAd = new InterstitialAd(InterstitialAdID);
        interstitialAd.LoadAd(new AdRequest.Builder().Build());;

        interstitialAd.OnAdClosed += HandlerOnClosed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // handle the interstitial ad
    public void HandlerOnClosed(object sender, EventArgs args )
    {
        SceneManager.LoadSceneAsync(level);
    }
    
    public void ShowAd(string levelToLoad)
    {
        if (interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
        }
        else
        {
            SceneManager.LoadSceneAsync(level);
        }

        level = levelToLoad;
    }
}
