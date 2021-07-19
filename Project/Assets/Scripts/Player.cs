using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float flyPower = 10;
    public float power = 40;
    private Rigidbody playerRigidBody;
    public Transform target;
    private float vertical;
    private float horizontal;
    public float rot = 0.25f;
    private Quaternion baseOrientation = new Quaternion(0, 0, 0,1);
    


    public float smoothTime = 0.3f;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var vel = playerRigidBody.velocity;      //to get a Vector3 representation of the velocity
        float speed = vel.magnitude;
        var playerRotation = transform.rotation;
        baseOrientation = transform.rotation;
        baseOrientation = new Quaternion(target.rotation.x, target.rotation.y, 0, target.rotation.w);
        horizontal = Input.GetAxis("Horizontal") * power * Time.deltaTime;
        vertical = Input.GetAxis("Vertical") * power * Time.deltaTime;
        playerRigidBody.AddForce(transform.forward * vertical * flyPower * Time.deltaTime);
        playerRigidBody.AddForce(transform.right * horizontal * flyPower * Time.deltaTime);
       
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidBody.AddForce(transform.up * flyPower * Time.deltaTime);
        }

        //if (!Input.anyKey)
        //{
            transform.rotation = Quaternion.Lerp(transform.rotation, baseOrientation, smoothTime);
        //}
        Debug.Log(vertical);
    
        
    }
}
