using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentLevel : MonoBehaviour
{
    private void Start()
    {
        TextMeshProUGUI levelLabel = GetComponent<TextMeshProUGUI>();
        levelLabel.text = "Уровень: " + SceneManager.GetActiveScene().name;
    }
}
