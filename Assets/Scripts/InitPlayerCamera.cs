using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private CarSelector carSelector;

    private void OnEnable() => carSelector.OnPlayerSpawned += InitCamera;
    private void OnDisable() => carSelector.OnPlayerSpawned -= InitCamera;

    private void InitCamera()
    {
        camera.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

}
