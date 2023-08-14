using TMPro;
using UnityEngine;

public class UISpeedUp : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeSpawnText;
    [SerializeField] private TMP_Text _timeWillBe;
    [SerializeField] private TMP_Text _priceButton;
    private void OnEnable()
    {
        SpeedUpGrowthButton.OnSpeedUpGrowth += ShowTimeSpawnText;
    }

    private void OnDisable()
    {
        SpeedUpGrowthButton.OnSpeedUpGrowth -= ShowTimeSpawnText;
    }

    private void ShowTimeSpawnText(float timeSpawn,int price, float timeWillBe)
    {
        _timeSpawnText.text =$"{timeSpawn}s";
        _priceButton.text= price.ToString();
        _timeWillBe.text= $"{timeWillBe}s";
    }
}
