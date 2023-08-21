using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private int _basketSize;
    [SerializeField] private int _numberFruitsRemove;
    [SerializeField] private float _timeFruitRemoval;

    private List<Fruit> _fruits = new List<Fruit>();
    private Coroutine _deleteFruitsCoroutine;
    private bool _isDelete=true;

    private void OnEnable()
    {
        FruitMovement.OnCut += IncreaseFruit;
    }

    private void OnDisable()
    {
        FruitMovement.OnCut -= IncreaseFruit;
    }

    private void IncreaseFruit(Fruit newFruit)
    {
        _fruits.Add(newFruit);

        TryRemovingExcessFruit();
    }
    private void TryRemovingExcessFruit()
    {
        if (IsFullness() && _isDelete)
        {
            _deleteFruitsCoroutine = StartCoroutine(DeleteFruitsCoroutine());
        }
    }

    private IEnumerator DeleteFruitsCoroutine()
    {
        _isDelete=false;
        WaitForSeconds waitForSeconds = new WaitForSeconds(_timeFruitRemoval);

        yield return waitForSeconds;

        DeleteFruits();
        TryRemovingExcessFruit();
    }

    private bool IsFullness() => _fruits.Count >= _basketSize;

    private void DeleteFruits()
    {
        for (int i = 0; i < _numberFruitsRemove; i++)
        {
            Destroy(_fruits[i].gameObject);
            _fruits.Remove(_fruits[i]);
        }

        UpdateListFruits();
    }

    private void UpdateListFruits()
    {
         List<Fruit> _newFruits = new List<Fruit>();

        foreach (Fruit newFruit in _fruits)
        {
            if (newFruit!=null)
            {
                _newFruits.Add(newFruit);
            }
        }
        _fruits=_newFruits;
        _isDelete = true;
    }
}
