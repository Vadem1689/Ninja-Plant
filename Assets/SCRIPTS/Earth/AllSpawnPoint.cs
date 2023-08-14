using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSpawnPoint : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private SpawnPlant _spawnPlant;

    private string _saverStatusSpawnPoint;
    private string _saverNumberModelPlant;

    private string _loaderStatusSpawnPoint;
    private string _loaderNumberModelPlant;
    private int _emptyModelPlant = 2;

    private void Start()
    {
        LoadPlant();
    }
    private void OnEnable()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.OnChangeStatus += SaveStatusSpawnPoint;
        }
    }

    private void OnDisable()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            spawnPoint.OnChangeStatus -= SaveStatusSpawnPoint;
        }
    }

    public void SaveStatusSpawnPoint()
    {
        _saverStatusSpawnPoint = null;
        _saverNumberModelPlant = null;

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            _saverStatusSpawnPoint += spawnPoint.StatusPoint.ToString();

            if (spawnPoint.Plant != null)
            {
                _saverNumberModelPlant += spawnPoint.Plant.CurrentIndexPlant.ToString();
            }
            else
            {
                _saverNumberModelPlant += _emptyModelPlant;
            }
            PlayerPrefs.SetString("StatusSpawnPoint", _saverStatusSpawnPoint);
            PlayerPrefs.SetString("NumberModelPlant", _saverNumberModelPlant);
        }
    } 


    public void LoadPlant()
    {
        if (PlayerPrefs.HasKey("StatusSpawnPoint") && PlayerPrefs.HasKey("NumberModelPlant"))
        {
            _loaderStatusSpawnPoint = PlayerPrefs.GetString("StatusSpawnPoint");
            _loaderNumberModelPlant = PlayerPrefs.GetString("NumberModelPlant");

            _spawnPlant.TryGetCountPoint(_loaderStatusSpawnPoint.Length);

            for (int i = 0; i <_loaderStatusSpawnPoint.Length; i++)
            {
                if (((int)Char.GetNumericValue(_loaderStatusSpawnPoint[i]) < 7))
                {
                    int newStatusSpawnPoint = (int)Char.GetNumericValue(_loaderStatusSpawnPoint[i]);
                    int newNumberModelPlant = (int)Char.GetNumericValue(_loaderNumberModelPlant[i]);
                    

                    Plant plant= _spawnPlant.LoadSpawn(_spawnPoints[i], newStatusSpawnPoint, newNumberModelPlant);
                    _spawnPoints[i].GetPlant(plant);
                }
            }
        }
    }
}
