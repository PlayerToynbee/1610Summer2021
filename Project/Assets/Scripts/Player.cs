using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private ResourceItem resource;
    private float enemyVel;
    public float flyPower = 500;
    public float power = 40;
    public float boostPower = 100;
    public float boostRate = 5;
    public float nextBoost;
    private Rigidbody playerRigidBody;
    private Rigidbody supplyRb;
    public Transform target;
    private float vertical;
    private float horizontal;
    public float rot = 0.25f;
    private Quaternion baseOrientation = new Quaternion(0, 0, 0, 1);
    private bool stun = false;
    public float stunVal = 0;
    public float stunMult = 1;
    public float stunRec = 5;
    private float speed;
    public bool isHolding = false;
    public GameObject resourceObj;
    public GameObject self;
    public GameObject grab;





public float smoothTime = 0.3f;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerRigidBody = GetComponent<Rigidbody>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag == "Enemy" && !stun)//&& speed > 300 && !stun)
        {
            stun = true;
            stunVal = 2;
        }
        if (collision.gameObject.CompareTag("Supply") && !isHolding)
        {
            supplyRb = collision.gameObject.GetComponent<Rigidbody>();
            resource = collision.gameObject.GetComponent<ResourceItem>();
            if (!resource.inCamp)
            {
                resource.isHeld = true;
                supplyRb.isKinematic = true;
                resourceObj = collision.gameObject;
                resourceObj.transform.position = grab.transform.position;
                //resourceObj.transform.rotation = transform.rotation;
                //resourceObj.transform.SetParent(self.gameObject.transform);
                isHolding = true;
                //gameObject.GetComponent<Transform>().SetParent(collision.collider.gameObject);
            }
        }
    }

    void Update()
    {
        var vel = playerRigidBody.velocity;      //to get a Vector3 representation of the velocity
        speed = vel.magnitude;
        var playerRotation = transform.rotation;
        //baseOrientation = transform.rotation;
        //baseOrientation = new Quaternion(target.rotation.x, target.rotation.y, 0, target.rotation.w);
        baseOrientation = target.rotation;
        if (!stun)
        {
            horizontal = Input.GetAxis("Horizontal") * power * Time.deltaTime;
            vertical = Input.GetAxis("Vertical") * power * Time.deltaTime;
            playerRigidBody.AddForce(transform.forward * vertical * 2 * flyPower * Time.fixedDeltaTime);
            playerRigidBody.AddForce(transform.right * horizontal * flyPower * Time.fixedDeltaTime);

            if (Input.GetKey(KeyCode.Space))
            {
                playerRigidBody.AddForce(transform.up * flyPower * 2 * Time.fixedDeltaTime);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > nextBoost)
            {
                nextBoost = Time.time + boostRate;
                playerRigidBody.AddForce(transform.forward * vertical * boostPower, ForceMode.VelocityChange);
                playerRigidBody.AddForce(transform.right * horizontal * boostPower, ForceMode.VelocityChange);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, baseOrientation, smoothTime);
        }

        if (isHolding) resourceObj.transform.position = grab.transform.position;

        if (isHolding && Input.GetKey(KeyCode.E))
        {
            supplyRb.isKinematic = false;
            resourceObj.transform.SetParent(null);
            supplyRb.AddForce(self.transform.forward * 10, ForceMode.Impulse);
            isHolding = false;
            resource.isHeld = false;
        }

        if (stunVal > 0)
        {
            stunVal = stunVal - (stunRec * Time.deltaTime);
            gameManager.StunScore(stunVal);
        }
        else stun = false;
        

        //}
        Debug.Log(speed);
    
        
    }


}
