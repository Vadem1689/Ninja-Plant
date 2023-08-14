using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ObgadeInfo", menuName = "ObgadeInfo")]
public class UpgradeInfo : ScriptableObject
{
    [field: SerializeField] public List<Upgrade> Upgades { get; private set; }
}

[Serializable]
public class Upgrade
{
    public int IncomMultiplaer;
    public int Cost;
}
