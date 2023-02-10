using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private Death death;
    [SerializeField] private CarSelector carSelector;

    private void OnEnable()
    {
        carSelector.OnPlayerSpawned += AttachDeathScript;
    }
    private void OnDisable()
    {
        death.OnPlayerDead -= ShowDeathPanel;
        carSelector.OnPlayerSpawned -= AttachDeathScript;
    }

    private void AttachDeathScript()
    {
        death = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        death.OnPlayerDead += ShowDeathPanel;
    }

    private void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
        restartButton.SetActive(false);

    }
}
