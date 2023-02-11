using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    private AudioSource audioSource;
    private void OnEnable()
    {
        Coin.OnCoinTaked += PlaySound;
    }
    private void OnDisable()
    {
        Coin.OnCoinTaked -= PlaySound;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlaySound()
    {
        audioSource.Play();
    }
}
