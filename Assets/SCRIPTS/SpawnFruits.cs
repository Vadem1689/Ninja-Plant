using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    [SerializeField] private Fruit _newFruit;

    private Basket _basket;
    private bool _isSpawn = false;

    public Fruit SpawnFruit(Fruit _currentFruit)
    {
        _newFruit = Instantiate(_currentFruit, gameObject.transform.position, _currentFruit.transform.rotation);

        _newFruit.transform.SetParent(transform, true);
        //_currentFruit.GetComponent<FruitMovement>().SetParentPlant(this);
        return _newFruit;
    }
}
