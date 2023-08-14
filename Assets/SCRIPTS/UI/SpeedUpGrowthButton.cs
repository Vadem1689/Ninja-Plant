using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SpeedUpGrowthButton : MonoBehaviour
{
    [SerializeField] private SpawnPlant _spawnPlant;
    [SerializeField] private int _priceButton;
    [SerializeField] private float _decreaseTime;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _increasePrice;
    [SerializeField] private SaverPlayerData _saverPlayer;
    [SerializeField] private float _spawnTime;

    private Button _button;
    
    public static Action<float,int,float> OnSpeedUpGrowth;

    public int PriceButton => _priceButton;
    public float DecreaseTime => _decreaseTime;
    public float SpawnTime => _spawnTime;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        if (_spawnPlant.GetPlants.Count > 0)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }
    public void OnButtonClick()
    {
        Plant plant = _spawnPlant.GetPlants[_spawnPlant.GetPlants.Count-1];

        if (_wallet.Coins>=_priceButton && _spawnPlant.GetPlants[0].SpawnTime>=2f)
        {
            _wallet.GiveAway(_priceButton);

            IncreasePrice();

            for (int i = 0; i < _spawnPlant.GetPlants.Count; i++)
            {
                _spawnPlant.GetPlants[i].UpSpeed(_decreaseTime);  
            }
            OnSpeedUpGrowth?.Invoke(((int)(plant.SpawnTime * 10)) / 10f, _priceButton,  //Надо ли в переменные?
                    ((int)((plant.SpawnTime - _decreaseTime) * 10)) / 10f);

            _saverPlayer.SaveSpeedUpGrowthButton(plant);
            _spawnTime=plant.SpawnTime;
        }
    }

    public void LoadDataButton(int price, float spawnTime, float willBeTime)
    {
        _spawnTime=spawnTime;
        _priceButton = price;

        for (int i = 0; i < _spawnPlant.GetPlants.Count; i++)
        {
            _spawnPlant.GetPlants[i].UpSpeed(spawnTime-willBeTime);
        }
        
        Plant plant = _spawnPlant.GetPlants[0];

        OnSpeedUpGrowth?.Invoke(((int)(spawnTime * 10)) / 10f, _priceButton,  //Надо ли в переменные?
                ((int)((willBeTime) * 10)) / 10f);        
    }

    private void IncreasePrice()
    {
        _priceButton+=_increasePrice;
    }
}
