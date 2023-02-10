using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class NextLevel : MonoBehaviour
{
    private void OnEnable()
    {
        LevelEnd.OnLevelEnd += ProcessFinish;
    }
    private void OnDisable()
    {
        LevelEnd.OnLevelEnd -= ProcessFinish;
    }

    private void ProcessFinish()
    {
        ChangeLevel();
        YandexGame.SaveProgress();
    }



    private void ChangeLevel()
    {
        YandexGame.savesData.currentLevel += 1;
        if (YandexGame.savesData.currentLevel > YandexGame.savesData.levelCount)
            YandexGame.savesData.currentLevel = 1;
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(YandexGame.savesData.currentLevel);
    }
}
