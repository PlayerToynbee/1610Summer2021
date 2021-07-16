using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, target.transform.rotation.y,target.transform.rotation.z);
        //Debug.Log(transform.rotation);
    }
}
