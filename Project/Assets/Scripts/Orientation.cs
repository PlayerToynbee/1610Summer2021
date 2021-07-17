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
        transform.Rotate(transform.rotation.x, target.transform.rotation.y,0);
        //Debug.Log(transform.rotation);
    }
}
