using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using UnityEngine.SceneManagement;

public class InitializeYandex : MonoBehaviour
{

#if UNITY_EDITOR

#endif

#if UNITY_WEBGL && !UNITY_EDITOR
    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize(OnInitialize);
    }
#endif

    private void OnInitialize()
    {
        SceneManager.LoadScene(1);
    }
}
