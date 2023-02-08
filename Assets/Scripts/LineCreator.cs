using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LineCreator : MonoBehaviour
{

    public GameObject[] linePrefabs;
    [SerializeField]
    private GameObject _selectedLine;

    Line activeLine;

    public void Awake()
    {
        Time.timeScale = 0f;
    }

    public void SelectSimpleLine()
    {
        _selectedLine = linePrefabs[0];

    }
    public void SelectBoostLine()
    {
        _selectedLine = linePrefabs[1];

    }
    public void SelectStopLine()
    {
        _selectedLine = linePrefabs[2];

    }
    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void StartLevel()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (Input.touchCount < 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!_selectedLine)
                {
                    _selectedLine = linePrefabs[0];
                }
                GameObject lineGO = Instantiate(_selectedLine);
                activeLine = lineGO.GetComponent<Line>();
            }

            if (Input.GetMouseButtonUp(0))
            {
                activeLine = null;
            }

            if (activeLine != null)
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                activeLine.UpdateLine(mousePos);

            }

        }


    }
}


