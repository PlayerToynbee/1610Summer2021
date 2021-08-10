using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CampScript : MonoBehaviour
{
    private ResourceItem resource;
    private GameManager gameManager;
    private Rigidbody resourceRb;
    public GameObject resourceObj; //contact object
    public GameObject camp;
    private bool contact;
    public Vector3 shrink = new Vector3(0.01f, 0.01f, 0.01f);
    public float shrinkSpeed = 0.9f;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Supply"))
        {
            resource = collision.gameObject.GetComponent<ResourceItem>();
            resourceRb = collision.gameObject.GetComponent<Rigidbody>();
            resource.inCamp = true;
            resourceRb.isKinematic = true;
            //gameManager.ResourceScore(resource.resourceValue);
            resourceObj = collision.gameObject;
            //resourceObj.transform.SetParent(camp.gameObject.transform);
            //gameObject.GetComponent<Transform>().SetParent(collision.collider.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        
        /*if (resourceObj.transform.localScale == shrink)
        {
            Destroy(resourceObj);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (resource.inCamp)
        {
            resourceObj.transform.position = Vector3.Lerp(resourceObj.transform.position, transform.position, 1);
            resourceObj.transform.localScale = Vector3.Lerp(resourceObj.transform.localScale, shrink, 1);
            if (shrink == resourceObj.transform.localScale) Destroy(resourceObj.gameObject);
        }
    }
    
}
