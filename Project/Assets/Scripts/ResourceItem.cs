using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceItem : MonoBehaviour
{
    public Rigidbody canRb;
    public float shrinkSpeed = 0.9f;
    public GameObject campObj;
    

    public bool isHeld = false;

    public bool inCamp = false;

    public Vector3 shrink = new Vector3(0.01f, 0.01f, 0.01f);
    // Start is called before the first frame update
    void Start()
    {
        canRb = GetComponent<Rigidbody>();
        campObj = GameObject.Find("Camp");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Camp")
        {
            inCamp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inCamp)
        {
            transform.position =
                Vector3.Lerp(transform.position, campObj.transform.position, Time.deltaTime * shrinkSpeed);
            transform.localScale = Vector3.Lerp(transform.localScale,
                shrink, Time.deltaTime * shrinkSpeed);
            if (shrink == transform.localScale) Destroy(gameObject);
        }
    }
}
