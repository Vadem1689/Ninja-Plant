using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPlant : MonoBehaviour
{
    [SerializeField] private SpeedUpGrowthButton _speedUpGrowth;
    [SerializeField] private int _pricePlant;
    [SerializeField] private int _increasePrice;
    [SerializeField] private int _maxPrice;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private Plant _plant;
    [SerializeField] List <SpawnPoint> _spawnPoints;
    [SerializeField] private Basket _basket;
    [SerializeField] private SaverPlayerData _playerData;

    private List<Plant> _plants= new List<Plant>();
    private int currentSpawnPoint = 0;
    private Earth _earth;

    public  event Action<int> OnBuyPlant;

    public List<Plant> GetPlants => _plants;
    public int PricePlant => _pricePlant;

    public void AddSpawnPoint(List<SpawnPoint> spawnPoints)
    {
        foreach (SpawnPoint spawnPoint in spawnPoints)
        {
            _spawnPoints.Add(spawnPoint);
        }
    }

    private void OnEnable()
    {
        Earth.OnBoughtEarthList += AddSpawnPoint;
    }

    private void OnDisable()
    {
        Earth.OnBoughtEarthList -= AddSpawnPoint;
    }

    private void Start()
    {
        if (_plants.Count == 0)
        {
            StartSpawn();
        }
    }

    public void TryGetCountPoint(int countPoint)
    {
        currentSpawnPoint=countPoint;
    }
    public void Spawn()
    {
        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            if (spawnPoint.IsBusy==false && _wallet.Coins >= _pricePlant)
            {
                _wallet.GiveAway(_pricePlant);
                IncreasePrice();
                OnBuyPlant?.Invoke(_pricePlant);

                Plant plant = Instantiate(_plant, FindFreeSpawnPoint().transform.position, _plant.transform.rotation);

                plant.Init(_basket);
                _plants.Add(plant);

                plant.GetSpawnPoint(FindFreeSpawnPoint());
                FindFreeSpawnPoint().GetPlant(_plants[_plants.Count - 1]);
                plant.UpSpeed(plant.SpawnTime - _speedUpGrowth.SpawnTime);
                currentSpawnPoint++;
                break;
            }
        }    
    }
    public void GetPricePlant(int price)
    {
        _pricePlant=price;
        OnBuyPlant?.Invoke(_pricePlant);
    }

    private void StartSpawn()
    {
       Plant plant= Instantiate(_plant, _spawnPoints[currentSpawnPoint].transform.position,
           _plant.transform.rotation);

        plant.Init(_basket);
        _plants.Add(plant);

        _plants[_plants.Count - 1].GetSpawnPoint(_spawnPoints[currentSpawnPoint]);

        _spawnPoints[currentSpawnPoint].GetPlant(_plants[_plants.Count-1]);
    }

    public void DecreaseSpawnPoint()
    {
        currentSpawnPoint--;
    }

    private SpawnPoint FindFreeSpawnPoint()
    {
        SpawnPoint spawnPoint = null;

        for (int i = 0; i < _spawnPoints.Count; i++)
        {
            if (_spawnPoints[i].IsBusy == false)
            {
                spawnPoint= _spawnPoints[i];
                break;
            }
        }
        return spawnPoint;
    }

    private void IncreasePrice()
    {
        if (_pricePlant< _maxPrice)
        {
            _pricePlant += _increasePrice;
        }
        _playerData.SavePriceButtonAddPlants();
    }

    public Plant LoadSpawn(SpawnPoint spawnPoint,int statusSpawnPoint, int numberModelPlant)
    {
        Plant plant = Instantiate(_plant, spawnPoint.transform.position, _plant.transform.rotation);

        plant.ChoosePlantModel(numberModelPlant);

        plant.ChangeCurrentFruit(statusSpawnPoint);

        plant.Init(_basket);
        _plants.Add(plant);

        plant.GetSpawnPoint(spawnPoint);
        plant.UpSpeed(plant.SpawnTime - _speedUpGrowth.SpawnTime);

        return plant;
    }
}
