using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private CarSelector carSelector;

    private void OnEnable()
    {
        carSelector.OnPlayerSpawned += InitCamera;
        LevelEnd.OnLevelEnd += DisableCameraFollow;
    }
    private void OnDisable()
    {
        carSelector.OnPlayerSpawned -= InitCamera;
        LevelEnd.OnLevelEnd -= DisableCameraFollow;
    }

    private void DisableCameraFollow()
    {
        camera.Follow = null;
    }

    private void InitCamera()
    {
        camera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
