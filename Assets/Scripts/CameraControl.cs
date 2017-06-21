using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity = 700.0f;

    float rotationX;
    float rotationY;

    private void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");

        float mouseMoveY = Input.GetAxis("Mouse Y");

        rotationX += sensitivity * mouseMoveY * Time.deltaTime;
        rotationY += sensitivity * mouseMoveX * Time.deltaTime;

        rotationX %= 360;
        rotationY %= 360;

        if(rotationX >= 90.0f)
        {
            rotationX = 90.0f;
        }
        else if(rotationX <= -90.0f)
        {
            rotationX = -90.0f; 
        }
       

        transform.eulerAngles = new Vector3(-rotationX, rotationY, 0.0f);
    }
}
