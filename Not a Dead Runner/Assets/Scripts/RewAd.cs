using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class RewAd : MonoBehaviour
{
    private string RewardedUnitId = "ca-app-pub-2195449399386566/4947987348";
    private RewardedAd rewardedAd;
    
    private void OnEnable()
    {
        rewardedAd = new RewardedAd(RewardedUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    private void HandleUserEarnedReward(object sender, Reward e)
    {
        int coins = PlayerPrefs.GetInt("coins");
        coins += 150;
        PlayerPrefs.SetInt("coins", coins);
        
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
            rewardedAd.Show();
    }
}
