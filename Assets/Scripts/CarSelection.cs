using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject nextButton;

    [Header("Choose/Buy Buttons")]
    [SerializeField] private Button chooseButton;
    [SerializeField] private Button buyButtton;
    [SerializeField] private TextMeshProUGUI carPrice;

    [Header("Car Attributes")]
    [SerializeField] private int[] carPrices;
    private int currentCar;

    private AudioSource source;

    [Header("Money")]
    [SerializeField] private TextMeshProUGUI moneyLabel;

    private bool[] carsUnlocked;


    private void OnEnable() => YandexGame.GetDataEvent += InitSaveData;

    private void OnDisable() => YandexGame.GetDataEvent -= InitSaveData;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        InitSaveData();
    }

    private void InitSaveData()
    {
        if (YandexGame.SDKEnabled)
        {
            currentCar = YandexGame.savesData.currentCar;
            YandexGame.savesData.newCarsUnlocked[0] = true;
            moneyLabel.text = YandexGame.savesData.money.ToString();
            SelectCar(currentCar);

            for (int i = 0; i < YandexGame.savesData.carsUnlocked.Length; i++)
            {
                YandexGame.savesData.newCarsUnlocked[i] = YandexGame.savesData.carsUnlocked[i];
            }
            YandexGame.savesData.levelCount = 25;
            YandexGame.SaveProgress();
        }
    }

    private void SelectCar(int index)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == index);
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (YandexGame.savesData.newCarsUnlocked[currentCar])
        {
            chooseButton.gameObject.SetActive(true);
            buyButtton.gameObject.SetActive(false);
        }
        else
        {
            chooseButton.gameObject.SetActive(false);
            buyButtton.gameObject.SetActive(true);
            carPrice.text = carPrices[currentCar].ToString();
        }
    }

    private void Update()
    {
        if (buyButtton.gameObject.activeInHierarchy)
        {
            buyButtton.interactable = (YandexGame.savesData.money >= carPrices[currentCar]);
        }
    }

    public void ChangeCar(int change)
    {
        currentCar += change;
        if (currentCar > transform.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = transform.childCount - 1;

        YandexGame.savesData.currentCar = currentCar;
        YandexGame.SaveProgress();
        SelectCar(currentCar);
    }
    public void BuyCar()
    {
        YandexGame.savesData.money -= carPrices[currentCar];
        YandexGame.savesData.newCarsUnlocked[currentCar] = true;
        moneyLabel.text = YandexGame.savesData.money.ToString();
        YandexGame.SaveProgress();
        source.Play();
        UpdateUI();
    }
}
