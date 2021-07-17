using System;
using System.Collections; 
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine; 
 
public class CameraControl : MonoBehaviour 
{ 
    public GameObject target;
    public float damping = 1;
    public Vector3 offset;
    public float rotateSpeed = 20;
    private Vector3 targetRotation;
    private float vertical;
    private float horizontal;



    void Start()
    {
        offset = target.transform.position - transform.position;
        transform.rotation = target.transform.rotation;
        transform.position = target.transform.position;
    }
     
    void LateUpdate()
    {
        
        var orientation = target.transform.rotation;
        targetRotation.x = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        targetRotation.y = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        //targetRotation.z = 0;
        //targetRotation.x = Mathf.Clamp(targetRotation.x, -40, 40);
        //transform.rotation = Quaternion.Euler(targetRotation);
        //float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        //float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //horizontal = transform.rotation.x;
        //vertical = transform.rotation.y;
        //transform.Rotate(vertical,horizontal, 0);
        //Quaternion cam = transform.rotation;
        //float currentAngle = transform.eulerAngles.y;
        //float desiredAngle = transform.eulerAngles.y;
        //Quaternion rotation = Quaternion.Euler(0,desiredAngle,0);
        //float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);
        //vertAngle = Input.GetAxis("Mouse Y");
        //horiAngle = Input.GetAxis("Mouse X");
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
        transform.position = target.transform.position - (transform.rotation * offset);
        transform.LookAt(target.transform);
        //Debug.Log(vertical + " " + horizontal);

    }
}
