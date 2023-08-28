using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private SpawnFruits _spawnFruits;

    [SerializeField] private Fruit _currentFruitPlant;

    //[SerializeField] private FruitObject _treeClass;
    [SerializeField] private List<Fruit> _fruitObject;
    [SerializeField] private GameObject _spawnPointFruit;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _currentIndexFruit;
    [SerializeField] private int _currentIndexPlant;
    [SerializeField] private ParticleSystem _plantEffect;
    [SerializeField] private Grabber _grabber;
    [SerializeField] private List<GameObject> _prefabPlant;

    private FruitMovement _fruitMovement;
    private Fruit _newFruit;
    private Basket _basket;
    private float _spawnTimeWas;
    private bool _isSpawn = true;
    private int _emptyModel = 2;

    public float SpawnTime => _spawnTime;
    public int CurrentIndexFruit => _currentIndexFruit;
    public int CurrentIndexPlant => _currentIndexPlant;

    private void Start()
    {
        _spawnTimeWas = _spawnTime;
        _spawnFruits = gameObject.GetComponentInChildren<SpawnFruits>();
    }

    private void Update()
    {
        if (_spawnTimeWas <= 0 && _isSpawn == true && _newFruit == null)
        {
            _newFruit = _spawnFruits.SpawnFruit(_currentFruitPlant);

            _fruitMovement = _newFruit.GetComponent<FruitMovement>();

            _spawnTimeWas = _spawnTime;
        }
        else
        {
            _spawnTimeWas -= Time.deltaTime;
        }

        if(_fruitMovement != null)
        {
            if (_fruitMovement.IsCut == true)
            {
                _newFruit = null;
            }
        }
    }

    public void StopSpawn()
    {
        _isSpawn = false;
    }

    public void StartSpawn()
    {
        _isSpawn = true;
    }

    public void CutFruit(Basket basket)
    {
        _fruitMovement.SetTargetMovement(basket);
        _fruitMovement.Jump();
    }

    public void ModificationFruit(Basket basket)
    {
        if (_currentIndexFruit < _fruitObject.Count)
        {
            _currentIndexFruit++;
            Modification();

            if (_currentFruitPlant.TryGetComponent(out FruitMovement _fruit))
            {
                CutFruit(basket);
            }
        }
    }

    private void Modification()
    {
        _currentFruitPlant = _fruitObject[_currentIndexFruit];
    }

    public void ChangeCurrentFruit(int currentFruit)
    {
        _currentIndexFruit = currentFruit;
        Modification(); // ���� �� ����� 
    }

    public void UpSpeed(float newTime)
    {
        if (_spawnTime <= newTime)
        {
            newTime = 0;
        }

        _spawnTime -= newTime;
    }
    //public void DeleteFruit()
    //{
    //    _currentFruitPlant = null;
    //}

    public void ImprovePlantModel()
    {
        if (_currentIndexPlant < _prefabPlant.Count - 1)
        {
            _currentIndexPlant++;
        }
        else
        {
            _currentIndexPlant = 0;
        }

        foreach (GameObject plantPrefab in _prefabPlant)
        {
            if (plantPrefab == _prefabPlant[_currentIndexPlant])
            {
                plantPrefab.SetActive(true);
            }
            else
            {
                plantPrefab.SetActive(false);
            }
        }
    }

    public void ChoosePlantModel(int modelPlant)
    {
        foreach (GameObject plantPrefab in _prefabPlant)
        {
            if (modelPlant < _emptyModel)
            {
                if (plantPrefab == _prefabPlant[modelPlant])
                {
                    plantPrefab.SetActive(true);
                }
                else
                {
                    plantPrefab.SetActive(false);
                }
            }
        }
    }

    public void PlayEffect()
    {
        _plantEffect.Play();
    }
}