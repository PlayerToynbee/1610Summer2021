using System;
using System.Collections; 
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine; 
 
public class CameraControl : MonoBehaviour 
{ 
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;
    public bool invertX;
    private int inv = -1;
     
    void Start()
    {
        if (invertX) inv = 1;
        offset = target.transform.position - transform.position;
    }
     
    void LateUpdate() 
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;// ori
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed * inv;
        target.transform.Rotate(vertical,horizontal,0);
        
       float desiredAngleY = transform.eulerAngles.y + horizontal;
       float desiredAngleX = transform.eulerAngles.x + vertical;
        Quaternion rotation = Quaternion.Euler(desiredAngleX, desiredAngleY, 0);
        transform.position = target.transform.position - (rotation * offset);
         
        transform.LookAt(target.transform);
        //Debug.Log("angle Y: " + desiredAngleY + ". angle X: " + desiredAngleX);
    }
}
