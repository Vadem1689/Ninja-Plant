using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private TMP_Text _nowPriceText;
    [SerializeField] private TMP_Text _willBeProfitText;

    public void ShowInfo(string priceText,  string nowPriceText, string willBeProfitText)
    {
        _priceText.text = priceText;
        _nowPriceText.text = nowPriceText;
        _willBeProfitText.text = willBeProfitText;
    }
}
