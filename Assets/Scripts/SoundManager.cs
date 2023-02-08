using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private UIManager uIManager;
    [SerializeField] private AudioMixer mainMixer;

    private void OnEnable() => uIManager.OnPlayerChangeVolume += ChangeMixerVolume;
    private void OnDisable() => uIManager.OnPlayerChangeVolume -= ChangeMixerVolume;


    private void ChangeMixerVolume(float volume)
    {
        mainMixer.SetFloat("SoundVolume", volume);
    }

}
