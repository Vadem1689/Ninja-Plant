using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Authorization : MonoBehaviour
{
    [SerializeField] private GameObject _liderboardPanel;

    public void Authorize()
    {
        if (PlayerAccount.IsAuthorized == false)
        {
            PlayerAccount.Authorize(RequestPersonalProfileDataPermission);
        }
        else
        {
            OpenLeaderboard();
        }
    }
    private void RequestPersonalProfileDataPermission()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();
    }

    private void OpenLeaderboard()
    {
        _liderboardPanel.SetActive(true);
    }
}

