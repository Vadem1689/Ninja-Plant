using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFruit : MonoBehaviour
{
    private Fruit _newFruit;

    private Basket _basket;
    private bool _isSpawn = false;


    public Fruit SpawnFruit(Fruit _currentFruit, Transform spawnPosition)
    {
        _newFruit = Instantiate(_currentFruit.gameObject, spawnPosition.position, _currentFruit.transform.rotation)
            .GetComponent<Fruit>();

        _newFruit.transform.SetParent(transform, true);
        //_currentFruit.GetComponent<FruitMovement>().SetParentPlant(this);
        return _newFruit;
    }
}
