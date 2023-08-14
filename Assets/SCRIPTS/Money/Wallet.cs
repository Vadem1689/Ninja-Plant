using Agava.YandexGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Earth _earth;

    private string _score = "Score";

    private int _currentMultiplie = 1;
    //private string _leaderboardName = "TopFarmer";
    private int _сounterReceivingMoney;
    private int _rightAmountAd = 10;


    public static Action OnEnableTutorialEarth;
    public string Score => _score;
    public int Coins => _coin.Coins;


    private void OnEnable()
    {
        FruitMovement.OnCut += IncreaseMoneyCuttingFruit;    //  FruitMovement полем сделать
    }

    private void OnDisable()
    {
        FruitMovement.OnCut -= IncreaseMoneyCuttingFruit;
    }

    public void IncreaseMoneyCuttingFruit(Fruit fruit)
    {
        _сounterReceivingMoney++;
        int _valueIncrease = fruit.Price * _currentMultiplie;

        _coin.IncreaseValue(_valueIncrease);;

        LearnAboutShowTutorialEarth();     // Надо ли их здесь оставлять?
        //LearnAboutIncreaseLeaderboard();
    }

    private void LearnAboutShowTutorialEarth()     //Название
    {
        if (_earth.Price == _coin.Coins)
        {
            OnEnableTutorialEarth?.Invoke();
        }
    }

    //    private void LearnAboutIncreaseLeaderboard()
    //    {
    //        if (_сounterReceivingMoney % _rightAmountAd == 0)   // Магические
    //        {

    //#if UNITY_WEBGL && !UNITY_EDITOR
    //             SetPlayerScore();
    //#endif
    //        }
    //    }

    //private void SetPlayerScore()
    //{
    //    if (YandexGamesSdk.IsInitialized)
    //    {
    //        Leaderboard.GetPlayerEntry(_leaderboardName, OnSuccessCallback);
    //    }
    //}

    //private void OnSuccessCallback(LeaderboardEntryResponse result)
    //{
    //    if (result != null || result.score < _coin.Coins)
    //    {
    //        Leaderboard.SetScore(_leaderboardName, _coin.Coins);
    //    }
    //}

    public bool GiveAway(int price)        // Нужен ли этот метод
    {
        if (_coin.DecreaseValue(price))
        {
            return true;
        }
        return false;
    }

    public bool TryPriceIncrease(int value, int cost)   //Нужен ли bool
    {
        if (_coin.DecreaseValue(cost))
        {
            PriceIncrease(value);
            return true;
        }
        return false;
    }
    public void PriceIncrease(int value)
    {
        _currentMultiplie = value;   // проверить название
    }

    public void GiveAdReward()
    {
        _coin.IncreaseValue(_coin.Coins);
    }

    public void LoadCoin(int coin)
    {
        _coin.IncreaseValue(coin);
    }
}
