using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class reklamlar : MonoBehaviour
{
    private InterstitialAd inter;
    public string idAndroid = "";
    public string idIos = "";
    private void Start()
    {
        this.Request();
    }
    private void Request()
    {
#if UNITY_ANDROID
             string id=idAndroid;
#elif UNITY_IPHONE
        string id = idIos;
#else
        string id="unexpected platform";
#endif
        this.inter = new InterstitialAd(id);
        this.inter.OnAdClosed += IntersitetialClosed;
        AdRequest request = new AdRequest.Builder().Build();
        this.inter.LoadAd(request);
    }
    private void IntersitetialClosed(object sender,EventArgs e)
    {
        this.Request();
    }
    public void Show()
    {
        this.inter.Show();
    }
}




