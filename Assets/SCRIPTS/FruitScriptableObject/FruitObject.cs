using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Fruit", menuName ="Fruit")]
public class FruitObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private Fruit _fruitPrefab;
    [SerializeField] private int _number;

    public Fruit FruitPrefab=>_fruitPrefab;
    public int Number => _number;

    public int Price=> _price;
    public string Name => _name;
}
