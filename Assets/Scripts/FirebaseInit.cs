using Firebase;
using Firebase.Analytics;
using GoogleMobileAds.Api;
using UnityEngine;

public class FirebaseInit : MonoBehaviour
{
    private BannerView bannerView;
    // Start is called before the first frame update
    // my ad id ca-app-pub-7467344290953936~5681050989
    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => 
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });   

        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }
}
