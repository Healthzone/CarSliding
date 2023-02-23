using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class RewardAd : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyLabel;
    // ������������� �� ������� �������� ������� � OnEnable
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    // ������������ �� ������� �������� ������� � OnDisable
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    // ����������� ����� ��������� �������
    private void Rewarded(int id)
    {
        YandexGame.savesData.money += 20;
        YandexGame.SaveProgress();
        moneyLabel.text = YandexGame.savesData.money.ToString();

    }

    // ����� ��� ������ ����� �������
    public void ShowRewardAD()
    {
        // �������� ����� �������� ����� �������
        YandexGame.RewVideoShow(0);
    }
}
