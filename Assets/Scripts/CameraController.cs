using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10.0f, speed = 15.0f, zoomSpeed = 10.0f;
    private float _mult = 1f;

    private void Update(){

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        

        float rotate = 0f;
        if(Input.GetKey(KeyCode.Q))
            rotate = -2f;
        else if(Input.GetKey(KeyCode.E))
            rotate = 2f;

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;

        transform.Rotate(UnityEngine.Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.Self);
        transform.Translate(new UnityEngine.Vector3(hor, 0, ver) * Time.deltaTime * _mult * speed, Space.Self);

        transform.position += transform.up * zoomSpeed * Input.GetAxis("Mouse ScrollWheel");

        transform.position = new UnityEngine.Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20.0f, 30.0f),
            transform.position.z
        );
    }
}
