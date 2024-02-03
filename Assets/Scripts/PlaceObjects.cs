using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlaceObjects : MonoBehaviour
{
    public LayerMask layer;
    public float rotateSpeed = 60f;

    private void Start(){
        PositionObject();
    }
    private void Update(){

        PositionObject();

        if(Input.GetMouseButtonDown(0)){
            Destroy(gameObject.GetComponent<PlaceObjects>());
        }

        if(Input.GetKey(KeyCode.LeftShift)){
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }
    }
    private void PositionObject(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000f, layer))
            transform.position = hit.point;
        
    }
}

