using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private SaverPlayerData _playerData;
    [SerializeField] private List<Earth> earths = new List<Earth>();

    private int _countEarthBuy=0;

    public void BuyEarth()
    {
        _countEarthBuy++;
        _playerData.SaveBoughtEarth(_countEarthBuy);
    }

    public void LoadBoughtEarth(int countBoughtEarth)
    {
        for (int i = 0; i < countBoughtEarth; i++)
        {
            earths[i].Buy();
        }
    }
}
