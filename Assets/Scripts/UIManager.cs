using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class UIManager : MonoBehaviour
{
    public Action<float> OnPlayerChangeVolume;

    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _menuPanel;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenShop()
    {
        _menuPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        _menuPanel.SetActive(true);
        _shopPanel.SetActive(false);
    }
    public void MuteSound()
    {
        _soundOn.SetActive(false);
        _soundOff.SetActive(true);
        OnPlayerChangeVolume?.Invoke(-80f);
    }
    public void UnmuteSound()
    {
        _soundOn.SetActive(true);
        _soundOff.SetActive(false);
        OnPlayerChangeVolume?.Invoke(0f);
    }

    public void StartGame()
    {
        if (YandexGame.SDKEnabled)
        {
            SceneManager.LoadScene(YandexGame.savesData.currentLevel);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
