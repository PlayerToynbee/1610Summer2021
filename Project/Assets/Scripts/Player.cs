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
    private bool stun = false;
    public float stunVal = 0;
    public float stunMult = 1;
    public float stunRec = 5;
    private float speed;
    
    


    public float smoothTime = 0.3f;

    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Surface" && speed > 10 && !stun)
        {
            stun = true;
            stunVal = (stunMult * speed) / 3;
        }
    }

    void Update()
    {
        var vel = playerRigidBody.velocity;      //to get a Vector3 representation of the velocity
        speed = vel.magnitude;
        var playerRotation = transform.rotation;
        //baseOrientation = transform.rotation;
        baseOrientation = new Quaternion(target.rotation.x, target.rotation.y, 0, target.rotation.w);
        if (!stun)
        {
            horizontal = Input.GetAxis("Horizontal") * power * Time.deltaTime;
            vertical = Input.GetAxis("Vertical") * power * Time.deltaTime;
            playerRigidBody.AddForce(transform.forward * vertical * 2 * flyPower * Time.deltaTime);
            playerRigidBody.AddForce(transform.right * horizontal * flyPower * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                playerRigidBody.AddForce(transform.up * flyPower * Time.deltaTime);
            }

            //if (!Input.anyKey)
            //{
            transform.rotation = Quaternion.Lerp(transform.rotation, baseOrientation, smoothTime);
        }

        if (stunVal > 0) stunVal = stunVal - (stunRec * Time.deltaTime);
        else stun = false;
        

        //}
        Debug.Log(speed + " X " + stunMult + " = " + (speed*stunMult)/2 + " Current: " + stunVal);
    
        
    }
}
