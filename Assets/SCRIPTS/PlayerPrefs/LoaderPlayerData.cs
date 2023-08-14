using UnityEngine;

public class LoaderPlayerData : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private SpawnPlant _spawnPlant;
    [SerializeField] private SpeedUpGrowthButton _speedUpGrowthButton;
    [SerializeField] private UpgradeSystem _obgadeSystem;
    [SerializeField] private EarthController _earthController;

    private int _coinCount;
    private int _newPricePlant;

    private int _priceSpeedUpGrowth;
    private float _spawnTime;
    private float _willBeTime;
    private int _currentLevelProfitIncrease;

    private void Start()
    {
        LoadCoins();
        LoadPriceButtonAddPlants();
        LoadSpeedUpGrowthButton();
        LoadProfitIncreaseButton();
        LoadBoughtEarth();
    }

    public void LoadCoins()
    {
        if (PlayerPrefs.HasKey("Coin"))
        {
            _coinCount = PlayerPrefs.GetInt("Coin");
            _wallet.LoadCoin(_coinCount);     //Устанавливаем значение название
        }
    }
    public void LoadPriceButtonAddPlants()
    {
        if (PlayerPrefs.HasKey("PricePlant"))
        {
            _newPricePlant = PlayerPrefs.GetInt("PricePlant");
            _spawnPlant.GetPricePlant(_newPricePlant);     
        }
    }
    public void LoadSpeedUpGrowthButton()
    {
        if (PlayerPrefs.HasKey("PriceSpeedUpGrowth")&&(PlayerPrefs.HasKey("SpawnTime"))&&
            (PlayerPrefs.HasKey("WiiBeTime")))
        {
            _priceSpeedUpGrowth = PlayerPrefs.GetInt("PriceSpeedUpGrowth");
            _spawnTime = PlayerPrefs.GetFloat("SpawnTime");
            _willBeTime = PlayerPrefs.GetFloat("WiiBeTime");

            _speedUpGrowthButton.LoadDataButton(_priceSpeedUpGrowth, _spawnTime, _willBeTime);
        }
    }

    public void LoadProfitIncreaseButton()
    {
        if (PlayerPrefs.HasKey("LevelProfitIncrease"))
        {
            _currentLevelProfitIncrease = PlayerPrefs.GetInt("LevelProfitIncrease");
            _obgadeSystem.LoadButton(_currentLevelProfitIncrease);
        }
    }

    public void LoadBoughtEarth()
    {
        if (PlayerPrefs.HasKey("CountBoughtEarth"))
        {
            _earthController.LoadBoughtEarth(PlayerPrefs.GetInt("CountBoughtEarth"));
        }
    }
}
