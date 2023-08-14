using TMPro;
using UnityEngine;

public class UISpawnPlant : MonoBehaviour
{
    [SerializeField] private TMP_Text _pricePlantText;
    [SerializeField] private SpawnPlant _spawnPlant;
    private void OnEnable()
    {
        _spawnPlant.OnBuyPlant += ShowPricePlant;
    }

    private void OnDisable()
    {
        _spawnPlant.OnBuyPlant -= ShowPricePlant;
    }

    private void ShowPricePlant(int pricePlant)
    {
        _pricePlantText.text =((int)(pricePlant*10)/10).ToString();  // Как сделать
    }
}
