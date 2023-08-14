using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private UpgradeInfo _data;
    [SerializeField] private Button _button;
    [SerializeField] private ButtonView _buttonView;
    [SerializeField] private SaverPlayerData _playerData;
    private int _intCurrentLevel = 0;

    public int CurrentLevel => _intCurrentLevel;

    public void Start()
    {
        _button.onClick.AddListener(SetMultiplaer);
    }

    public void LoadButton(int currentLevel)
    {
        if (currentLevel< _data.Upgades.Count )
        {
            _intCurrentLevel = currentLevel;
            _wallet.PriceIncrease(_data.Upgades[_intCurrentLevel-1].IncomMultiplaer);

            _buttonView.ShowInfo(_data.Upgades[_intCurrentLevel/*-1*/].Cost.ToString(),
               _data.Upgades[_intCurrentLevel - 1].IncomMultiplaer.ToString(),
               _data.Upgades[_intCurrentLevel].IncomMultiplaer.ToString());
        }
    }

    private void SetMultiplaer()
    {
        if (_intCurrentLevel + 1 < _data.Upgades.Count - 1 && _wallet.TryPriceIncrease
            (_data.Upgades[_intCurrentLevel].IncomMultiplaer,_data.Upgades[_intCurrentLevel].Cost) )
        {
            _buttonView.ShowInfo(_data.Upgades[_intCurrentLevel+1].Cost.ToString(),
                _data.Upgades[_intCurrentLevel].IncomMultiplaer.ToString(),
                _data.Upgades[_intCurrentLevel+1].IncomMultiplaer.ToString());

            _intCurrentLevel++;
            _playerData.SaveProfitIncreaseButton(_intCurrentLevel);

        }
    }
}
