using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADManager : MonoBehaviour
{

    private string APP_ID = "ca-app-pub-7971314391680030~2741855169";

    private BannerView bannerAD;
    private InterstitialAd interstitialAD;
    private RewardBasedVideoAd videoAD;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {

        // This is when you publish your app
        MobileAds.Initialize(APP_ID);

        RequestBanner();
        RequestInterstitial();
        RequestVideoAd();
        Display_Banner();

    }

    void RequestBanner()
    {
        //demo
        //string banner_ID = "ca-app-pub-3940256099942544/6300978111";

        // Real
        string banner_ID = "ca-app-pub-7971314391680030/4064290093";
        bannerAD = new BannerView(banner_ID, AdSize.SmartBanner, AdPosition.Top);

        //FOR REAL
        AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder()
        //    .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        bannerAD.LoadAd(adRequest);

    }

    void RequestInterstitial()
    {
        // Demo
        //string Interstitial_ID = "ca-app-pub-3940256099942544/1033173712";

        //real
        string Interstitial_ID = "ca-app-pub-7971314391680030/6699026442";

        interstitialAD = new InterstitialAd(Interstitial_ID);

        //FOR REAL
        AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        //AdRequest adRequest = new AdRequest.Builder()
        //    .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        interstitialAD.LoadAd(adRequest);

    }

    void RequestVideoAd()
    {
        // Demo
        string Video_ID = "ca-app-pub-3940256099942544/5224354917";

        //real
        //string Video_ID = "ca-app-pub-3940256099942544/5224354917";

        videoAD = RewardBasedVideoAd.Instance;

        //FOR REAL
        //AdRequest adRequest = new AdRequest.Builder().Build();

        // FOR TESTING
        AdRequest adRequest = new AdRequest.Builder()
            .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b").Build();

        videoAD.LoadAd(adRequest, Video_ID);

    }

    public void Display_Banner()
    {
        bannerAD.Show();
    }

    public void DisplayInterstitialAD()
    {

        if (interstitialAD.IsLoaded())
        {
            interstitialAD.Show();
        }

    }

    public void Display_VideoAD()
    {
        if (videoAD.IsLoaded())
        {
            videoAD.Show();
        }
    }


    // HANDLE EVENTS

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Display_Banner();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    void HandleBannerADEvents(bool subscriber)
    {
        if (subscriber)
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded += HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad += HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening += HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed += HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        }
        else
        {
            // Called when an ad request has successfully loaded.
            bannerAD.OnAdLoaded -= HandleOnAdLoaded;
            // Called when an ad request failed to load.
            bannerAD.OnAdFailedToLoad -= HandleOnAdFailedToLoad;
            // Called when an ad is clicked.
            bannerAD.OnAdOpening -= HandleOnAdOpened;
            // Called when the user returned from the app after an ad click.
            bannerAD.OnAdClosed -= HandleOnAdClosed;
            // Called when the ad click caused the user to leave the application.
            bannerAD.OnAdLeavingApplication -= HandleOnAdLeavingApplication;
        }

    }


    void OnEnable()
    {
        HandleBannerADEvents(true);
    }

    void OnDisable()
    {
        HandleBannerADEvents(false);
    }

}
