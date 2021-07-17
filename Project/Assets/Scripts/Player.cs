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
    public float rot = 0.25f;
    private Quaternion baseOrientation = new Quaternion(0, 0, 0,1);
    


    public float smoothTime = 0.3f;

    private void Start()
    {
        baseOrientation.y = target.rotation.y;
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var vel = playerRigidBody.velocity;      //to get a Vector3 representation of the velocity
        float speed = vel.magnitude;
        var playerRotation = transform.rotation;
      
        horizontal = -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
        transform.Rotate(vertical, transform.rotation.y, horizontal);
        playerRotation.x = Mathf.Clamp(transform.rotation.x, -rot, rot);
        playerRotation.z = Mathf.Clamp(transform.rotation.z, -rot, rot);
        playerRotation.y = transform.rotation.y;
        //transform.Rotate(playerRotation.x,transform.rotation.y, playerRotation.z);
        transform.rotation = playerRotation;
        
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidBody.AddForce(transform.up * flyPower * Time.deltaTime);
        }

        if (!Input.anyKey)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, baseOrientation, smoothTime * (speed/100));
        }
        Debug.Log(speed);
    
        
    }
}
