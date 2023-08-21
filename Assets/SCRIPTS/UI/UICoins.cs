using TMPro;
using UnityEngine;

public class UICoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinsCountText;

    private void OnEnable()
    {
        Wallet.OnChangeNumberCoins += ShowCountCoins;
    }

    private void OnDisable()
    {
        Wallet.OnChangeNumberCoins -= ShowCountCoins;
    }

    private void ShowCountCoins(int coinCount)
    {
        _coinsCountText.text = coinCount.ToString();
    }
}
