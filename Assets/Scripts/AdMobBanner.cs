using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class AdMobBanner : MonoBehaviour
{
    public static AdMobBanner instance;
    
    public string AppID;
    public string BannerAdUnitID;

    private BannerView bannerView;
    
    
    void Awake()
    {
        // keep AdManager instance alive
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject); // there is already an instance so detroy


    }
    
    // Start is called before the first frame update
    void Start()
    
    {
        MobileAds.Initialize(AppID);
        bannerView = new BannerView(BannerAdUnitID, AdSize.Banner, AdPosition.Top);
        bannerView.LoadAd(new AdRequest.Builder().Build());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ShowAd()
    {
        bannerView.Show();
    }
}
