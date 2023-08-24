using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AdButton : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Grabber _graber;
    [SerializeField] private AudioMuteHandler _audioMuteHandler;

    private bool _adIsPlaying;

    public bool AdIsPlaying => _adIsPlaying;

    private void OnEnable()
    {
        Grabber.OnallAd += PlayAd;
    }

    private void OnDisable()
    {
        Grabber.OnallAd -= PlayAd;
    }

    public void OnShowVideoButtonClick()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        VideoAd.Show(OnPlayed, OnRewarded,OnClosed);
#endif
    }

    private void OnRewarded()    
    {
        _wallet.GiveAdReward();
    }

    private void OnClosed()
    {
        _audioMuteHandler.UnmuteAudio();
        _adIsPlaying = false;
    }

    private void OnPlayed()
    {
        _audioMuteHandler.MuteAudio();
        _adIsPlaying = true;
    }

    private void ShowInterstitialAd()
    {
        InterstitialAd.Show(OnPlayed, OnClosedInterstitialAd);
    }

    private void PlayRegularAdIf(bool value)
    {
        if (value)
        {
            ShowInterstitialAd();
        }
    }

    private void PlayAd()   //��������
    {
        ShowInterstitialAd();
    }

    private void OnClosedInterstitialAd(bool value)
    {
        _audioMuteHandler.UnmuteAudio();
        _adIsPlaying = false;
    }
}
