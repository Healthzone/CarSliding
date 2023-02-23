using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class RewardAd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyLabel;
    // Подписываемся на событие открытия рекламы в OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    // Отписываемся от события открытия рекламы в OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    // Подписанный метод получения награды
    private void Rewarded(int id)
    {
        YandexGame.savesData.money += 20;
        YandexGame.SaveProgress();
        moneyLabel.text = YandexGame.savesData.money.ToString();

    }

    // Метод для вызова видео рекламы
    public void ShowRewardAD()
    {
        // Вызываем метод открытия видео рекламы
        YandexGame.RewVideoShow(0);
    }
}
