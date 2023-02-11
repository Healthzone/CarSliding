using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class MoneyLabel : MonoBehaviour
{
    private TextMeshProUGUI label;
    private int coinCount;

    public int CoinCount { get => coinCount; }

    private void OnEnable()
    {
        YandexGame.GetDataEvent += InitMoneyLabel;
        Coin.OnCoinTaked += ChangeCoinCount;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= InitMoneyLabel;
        Coin.OnCoinTaked -= ChangeCoinCount;
    }

    private void ChangeCoinCount()
    {
        ++coinCount;
        label.text = coinCount.ToString();
    }

    private void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        if (YandexGame.SDKEnabled)
            InitMoneyLabel();
    }
    private void InitMoneyLabel()
    {
        coinCount = YandexGame.savesData.money;
        label.text = coinCount.ToString();
    }
}
