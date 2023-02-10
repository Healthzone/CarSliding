using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CarSelector carSelector;

    private Death deathScript;

    private TextMeshProUGUI timeLabel;
    private void OnEnable()
    {
        carSelector.OnPlayerSpawned += InitCounter;
    }
    private void OnDisable()
    {
        carSelector.OnPlayerSpawned -= InitCounter;
    }
    private void Start()
    {
        timeLabel = GetComponent<TextMeshProUGUI>();
    }
    private void InitCounter()
    {
        deathScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        deathScript.OnDeathTimeChanged += ChangeCounterTime;
    }

    private void ChangeCounterTime(float time)
    {
        if (!timeLabel.enabled && !deathScript.IsDead)
            timeLabel.enabled = true;
        else if (deathScript.IsDead)
            timeLabel.enabled = false;
        timeLabel.text = Convert.ToInt32(Mathf.Ceil(time)).ToString();
    }
}
