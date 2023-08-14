using UnityEngine;

public class SaverPlayerData : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private SpawnPlant _spawnPlant;
    [SerializeField] private SpeedUpGrowthButton _speedUpGrowthButton;

    public void SaveCoin()
   {
        PlayerPrefs.SetInt("Coin", _wallet.Coins);  
   }

   public void SavePriceButtonAddPlants()
    {
        PlayerPrefs.SetInt("PricePlant", _spawnPlant.PricePlant);
    }

    public void SaveSpeedUpGrowthButton(Plant _plant)
    {
        PlayerPrefs.SetInt("PriceSpeedUpGrowth", _speedUpGrowthButton.PriceButton);
        PlayerPrefs.SetFloat("SpawnTime", _plant.SpawnTime);
        PlayerPrefs.SetFloat("WiiBeTime", _plant.SpawnTime - _speedUpGrowthButton.DecreaseTime);
    }

    public void SaveProfitIncreaseButton(int intCurrentLevel)
    {
        PlayerPrefs.SetInt("LevelProfitIncrease", intCurrentLevel);
    }

    public void SaveBoughtEarth(int countBoughtEarth)
    {
        PlayerPrefs.SetInt("CountBoughtEarth", countBoughtEarth);
    }
}
