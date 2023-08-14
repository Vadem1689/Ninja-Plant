using Lean.Localization;
using UnityEngine;
using Agava.YandexGames;

public class LocaleSelector : MonoBehaviour
{
    [SerializeField] private LeanLocalization _leanLocalization;
    private const string EnglishCode = "en";
    private const string RussianCode = "ru";
    private const string TurkishCode = "tr";
    private const string EnglishLanguage = "English";
    private const string RussianLanguage = "Russian";
    private const string TurkishLanguage = "Turkish";

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SwitchLanguageTo(YandexGamesSdk.Environment.i18n.lang);
#endif
    }

    private void SwitchLanguageTo(string code)
    {
        switch (code)
        {
            case EnglishCode:
               _leanLocalization.SetCurrentLanguage(EnglishLanguage);
                break;

            case RussianCode:
                _leanLocalization.SetCurrentLanguage(RussianLanguage);
                break;

            case TurkishCode:
                _leanLocalization.SetCurrentLanguage(TurkishLanguage);
                break;

            default:
                _leanLocalization.SetCurrentLanguage(EnglishLanguage);
                break;
        }
    }
}
