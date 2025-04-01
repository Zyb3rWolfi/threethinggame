using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScroller : Scroller
{
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        if (_camera == null)
        {
            Debug.LogError("Camera not found");
        }
        speed = 1f;
    }
    public override string getType()
    {
        return "sky";
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, _camera.transform.position.y, gameObject.transform.position.z);
    }

    public override void ChangeSpeed(float newSpeed) {
        speed = 1f + (0.5f * newSpeed);
    }

}
