using System;
using System.Collections; 
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine; 
 
public class CameraControl : MonoBehaviour 
{ 
    public GameObject target;
    public float damping = 1;
    Vector3 offset;
    public float rotateSpeed = 5;


    void Start()
    {
        offset = target.transform.position - transform.position;
    }
     
    void LateUpdate()
    {
        float horizontalCam = Input.GetAxis("Mouse X") * rotateSpeed;
        float verticalCam = Input.GetAxis("Mouse Y") * rotateSpeed;
        transform.Rotate(verticalCam,horizontalCam, 0);
        //Quaternion cam = transform.rotation;
        //float currentAngle = transform.eulerAngles.y;
        //float desiredAngle = transform.eulerAngles.y;
        //Quaternion rotation = Quaternion.Euler(0,desiredAngle,0);
        //float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        //vertAngle = Input.GetAxis("Mouse Y");
        //horiAngle = Input.GetAxis("Mouse X");
        Quaternion rotation = Quaternion.Euler(verticalCam, horizontalCam, 0);
        //transform.position = target.transform.position - (rotation * offset);
        transform.RotateAround(target.transform.position, Vector3.up, horizontalCam);
        transform.RotateAround(target.transform.position, Vector3.right, verticalCam);
        transform.LookAt(target.transform);
        Debug.Log(verticalCam + " " + horizontalCam);
        
    }
}
