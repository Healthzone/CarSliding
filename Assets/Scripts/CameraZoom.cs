using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


[RequireComponent(typeof(Camera))]

public class CameraZoom : MonoBehaviour
{
    

    [SerializeField] private float MouseZoomSpeed = 15.0f;
    [SerializeField] private float TouchZoomSpeed = 0.1f;
    [SerializeField] private float ZoomMinBound = 0.1f;
    [SerializeField] private float ZoomMaxBound = 179.9f;
    [SerializeField] private CinemachineVirtualCamera cam;

    

    void Update()
    {
        if (Input.touchSupported)
        {
            // Pinch to zoom
            if (Input.touchCount == 2)
            {

                // get current touch positions
                Touch tZero = Input.GetTouch(0);
                Touch tOne = Input.GetTouch(1);
                // get touch position from the previous frame
                Vector2 tZeroPrevious = tZero.position - tZero.deltaPosition;
                Vector2 tOnePrevious = tOne.position - tOne.deltaPosition;

                float oldTouchDistance = Vector2.Distance(tZeroPrevious, tOnePrevious);
                float currentTouchDistance = Vector2.Distance(tZero.position, tOne.position);

                // get offset value
                float deltaDistance = oldTouchDistance - currentTouchDistance;
                Zoom(deltaDistance, TouchZoomSpeed);
            }
        }
        else
        {

            float scroll = Input.GetAxis("Mouse ScrollWheel");
            Zoom(scroll, MouseZoomSpeed);
        }



        if (cam.m_Lens.OrthographicSize < ZoomMinBound)
        {
            cam.m_Lens.OrthographicSize = 0.1f;
        }
        else
        if (cam.m_Lens.OrthographicSize > ZoomMaxBound)
        {
            cam.m_Lens.OrthographicSize = 179.9f;
        }
    }

    void Zoom(float deltaMagnitudeDiff, float speed)
    {

        cam.m_Lens.OrthographicSize += deltaMagnitudeDiff * speed;
        // set min and max value of Clamp function upon your requirement
        cam.m_Lens.OrthographicSize = Mathf.Clamp(cam.m_Lens.OrthographicSize, ZoomMinBound, ZoomMaxBound);
    }
}