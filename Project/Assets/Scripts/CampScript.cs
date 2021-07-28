using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampScript : MonoBehaviour
{
    private Rigidbody supplyRb;
    public GameObject resourceObj;
    public GameObject camp;
    private bool contact;
    public Vector3 shrink = new Vector3(0.01f, 0.01f, 0.01f);
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Supply"))
        {
            supplyRb = collision.gameObject.GetComponent<Rigidbody>();
            supplyRb.isKinematic = true;
            resourceObj = collision.gameObject;
            resourceObj.transform.SetParent(camp.gameObject.transform);
            //gameObject.GetComponent<Transform>().SetParent(collision.collider.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (resourceObj.transform.localScale == shrink)
        {
            Destroy(resourceObj);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(resourceObj.transform.localScale);
    }
    
}
