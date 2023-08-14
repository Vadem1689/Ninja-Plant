using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUpdate : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private string _leaderboardName = "TopFarmer";

    private void Start()
    {
        StartCoroutine(WaitAndPrintMessage());
    }

    private IEnumerator WaitAndPrintMessage()
    {
        while (true)
        {
#if UNITY_WEBGL && !UNITY_EDITOR
             SetPlayerScore();
#endif
             yield return new WaitForSeconds(180); 
        }
    }

    private void SetPlayerScore()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            Leaderboard.GetPlayerEntry(_leaderboardName, OnSuccessCallback);
        }
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {
        if (result != null || result.score < _wallet.Coins)
        {
            Leaderboard.SetScore(_leaderboardName, _wallet.Coins);
        }
    }
}
