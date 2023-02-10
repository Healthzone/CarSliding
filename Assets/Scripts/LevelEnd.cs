using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public static Action OnLevelEnd;

    [SerializeField] private GameObject endLevelPanel;
    [SerializeField] private GameObject retryButton;


    private void ShowEndLevelPanel()
    {
        endLevelPanel.SetActive(true);
        retryButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            OnLevelEnd?.Invoke();
            ShowEndLevelPanel();
        }
    }

}
