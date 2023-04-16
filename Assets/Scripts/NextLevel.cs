using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private MoneyLabel moneyLabel;
    private void OnEnable()
    {
        LevelEnd.OnLevelEnd += ProcessFinish;
    }
    private void OnDisable()
    {
        LevelEnd.OnLevelEnd -= ProcessFinish;
    }

    private IEnumerator ShowInterstitial()
    {
        yield return new WaitForSeconds(0.75f);
        YandexGame.FullscreenShow();
    }

    private void ProcessFinish()
    {
        StartCoroutine(ShowInterstitial());
        ChangeLevel();
        YandexGame.savesData.money = moneyLabel.CoinCount;
        YandexGame.SaveProgress();
    }



    private void ChangeLevel()
    {
        YandexGame.savesData.currentLevel += 1;
        Debug.Log(YandexGame.savesData.currentLevel);
        if (YandexGame.savesData.currentLevel > YandexGame.savesData.levelCount)
            YandexGame.savesData.currentLevel = 1;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(YandexGame.savesData.currentLevel);
    }
}
