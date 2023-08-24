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
    private int _ounterReceivingMoney;
    private int _rightAmountAd = 10;


    public static Action OnEnableTutorialEarth;
    public static Action<int> OnChangeNumberCoins;
    public string Score => _score;
    public int Coins => _coin.Coins;


    private void OnEnable()
    {
        FruitMovement.OnCut += IncreaseMoneyCuttingFruit;   
    }

    private void OnDisable()
    {
        FruitMovement.OnCut -= IncreaseMoneyCuttingFruit;
    }

    public void IncreaseMoneyCuttingFruit(Fruit fruit)
    {
        _ounterReceivingMoney++;
        int _valueIncrease = fruit.Price * _currentMultiplie;

        _coin.IncreaseValue(_valueIncrease);
        OnChangeNumberCoins?.Invoke(_coin.Coins);

        LearnAboutShowTutorialEarth();     // ���� �� �� ����� ���������?
    }

    private void LearnAboutShowTutorialEarth()     //��������
    {
        if (_earth.Price == _coin.Coins)
        {
            OnEnableTutorialEarth?.Invoke();
        }
    }

    public bool GiveAway(int price)        // ����� �� ���� �����
    {
        if (_coin.DecreaseValue(price))
        {
            return true;
        }
        return false;
    }

    public bool TryPriceIncrease(int value, int cost)   //����� �� bool
    {
        if (_coin.DecreaseValue(cost))
        {
            PriceIncrease(value);
            OnChangeNumberCoins?.Invoke(_coin.Coins);
            return true;
        }
        return false;
    }
    public void PriceIncrease(int value)
    {
        _currentMultiplie = value;   // ��������� ��������
    }

    public void GiveAdReward()
    {
        _coin.IncreaseValue(_coin.Coins);
        OnChangeNumberCoins?.Invoke(_coin.Coins);
    }

    public void LoadCoin(int coin)
    {
        _coin.IncreaseValue(coin);
        OnChangeNumberCoins?.Invoke(_coin.Coins);
    }
}
