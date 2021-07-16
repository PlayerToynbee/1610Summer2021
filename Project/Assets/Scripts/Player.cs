using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float flyPower = 10;
    public float rotationSpeed = 40;
    private Rigidbody playerRigidBody;
    public Transform target;
    private float vertical;
    private float horizontal;
    private float rotMax = 45;
    private float rotMin = 325;
    private Quaternion baseOrientation = new Quaternion(0, 0, 0,1);
    


    public float smoothTime = 0.3f;

    private void Start()
    {
        baseOrientation = target.rotation;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var vel = playerRigidBody.velocity;      //to get a Vector3 representation of the velocity
        float speed = vel.magnitude;
      
        horizontal = -Input.GetAxis("Horizontal")/* * rotationSpeed * Time.deltaTime*/;
        //horizontal = Mathf.Clamp(horizontal, -0.25f, 0.25f);
        transform.Rotate(transform.rotation.x, transform.rotation.y, horizontal);
        vertical = Input.GetAxis("Vertical")/* * rotationSpeed * Time.deltaTime*/;
        transform.Rotate(vertical,transform.rotation.y, transform.rotation.z);
        if (transform.eulerAngles.x > 45 && transform.eulerAngles.x < 100) transform.rotation = Quaternion.Euler(rotMax, transform.rotation.y, transform.rotation.z);
        if (transform.eulerAngles.x <= 325 && transform.eulerAngles.x > 100) transform.rotation = Quaternion.Euler(rotMin, transform.rotation.y, transform.rotation.z);
        if (transform.eulerAngles.z > 45 && transform.eulerAngles.z < 100) transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotMax);
        if (transform.eulerAngles.z <= 325 && transform.eulerAngles.z > 100) transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotMin);
        
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidBody.AddForce(transform.up * flyPower);
        }

        if (!Input.anyKey)
        {
            //var newPositionX = Mathf.SmoothDamp(transform.rotation.x, target.transform.rotation.x , ref xVelocity, smoothTime);
            //var newPositionZ = Mathf.SmoothDamp(transform.rotation.z, target.transform.rotation.z , ref xVelocity, smoothTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, baseOrientation, smoothTime);
            //transform.Rotate(newPositionX, transform.rotation.y, newPositionZ);
            //transform.rotation = Mathf.SmoothDamp(transform.rotation)
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Debug.Log(transform.eulerAngles);
    
        
    }
}
