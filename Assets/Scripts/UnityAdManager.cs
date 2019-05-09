using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdManager : MonoBehaviour
{
    public static UnityAdManager instance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // this will be called to show an advertisement
    public void ShowAd()
    {
        // check if AdCount key has been added already
        if (PlayerPrefs.HasKey("AdCount"))
        {
            // show an ad after 3 gameovers
            if (PlayerPrefs.GetInt("AdCount") == 5)
            {
                // Check if there is a loaded ad
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    Advertisement.Show("rewardedVideo");
                }
                // ad watched so reset count
                PlayerPrefs.SetInt("AdCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("AdCount", PlayerPrefs.GetInt("AdCount") + 1);
            }
        }
 
       else
       {
           // set up AdCount Key at 0
           PlayerPrefs.SetInt("AdCount", 0);
       }

    }
}
