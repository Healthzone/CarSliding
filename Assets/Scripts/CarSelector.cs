using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using YG;

public class CarSelector : MonoBehaviour
{
    public Action OnPlayerSpawned;

    [SerializeField] private GameObject[] cars;
    private GameObject spawnedCar;

    private void OnEnable() => YandexGame.GetDataEvent += InstantiateCar;

    private void OnDisable() => YandexGame.GetDataEvent -= InstantiateCar;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            InstantiateCar();
        }
    }

    public void InstantiateCar()
    {
        if (spawnedCar != null)
        {
            Destroy(spawnedCar);
        }
        if (YandexGame.savesData.newCarsUnlocked[YandexGame.savesData.currentCar])
            spawnedCar = Instantiate(cars[YandexGame.savesData.currentCar], transform.position, Quaternion.identity);
        else
            spawnedCar = Instantiate(cars[0], transform.position, Quaternion.identity);
        spawnedCar.GetComponentInChildren<ParticleSystem>().Play();
        OnPlayerSpawned?.Invoke();
    }
}
