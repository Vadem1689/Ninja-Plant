using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _hand;
    [SerializeField] private Earth _earth;
    [SerializeField] private Animator _animatorHead;
    [SerializeField] private Wallet _wallet;

    private bool _isCutting;
    private int _saverShowEarthAnim=0;

    private void OnEnable()
    {
        Wallet.OnEnableTutorialEarth += ShowBuyingEarth;    
    }
    private void OnDisable()
    {
        Wallet.OnEnableTutorialEarth -= ShowBuyingEarth;
    }

    private void Start()
    {
        TryFindKey();
    }

    private void Update()
    {
        if (!_isCutting)
        {
            StartCuttingPlayer();
        }
        
        if (_earth.IsBoughtEarth)
        {
            _hand.SetActive(false);
            gameObject.SetActive(false);

            _saverShowEarthAnim = 2;
            PlayerPrefs.SetInt("ShowEarthAnimCutting", _saverShowEarthAnim);
        }
    }

    private void StartCuttingPlayer()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            _animatorHead.SetTrigger("ShowEarth");
            _hand.SetActive(false);
            _isCutting = true;

            _saverShowEarthAnim = 1;
            PlayerPrefs.SetInt("ShowEarthAnimCutting", _saverShowEarthAnim);
        }
    }

    private void TryFindKey()
    {
        if (PlayerPrefs.HasKey("ShowEarthAnimCutting"))
        {
            _hand.SetActive(false);
        }
    }
    private void ShowBuyingEarth()
    {
        if ( PlayerPrefs.GetFloat("ShowEarthAnimCutting")!=2)
        {
            _hand.SetActive(true);
        }
    }
}
