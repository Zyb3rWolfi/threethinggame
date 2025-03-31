using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    private Camera cam;
    public float zoomSpeed = 2f;
    public float zoomOutMax = 7;
    public float zoomInMax = 3;
        
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.z = -10;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothSpeed * Time.deltaTime);
    }

    public void ChangeCameraZoom(float currentSpeed)
    {
        if (currentSpeed > 5)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomOutMax, Time.deltaTime * zoomSpeed);
        }
        else if (currentSpeed < 5)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoomInMax, Time.deltaTime * zoomSpeed);
        }
    }
    
}
