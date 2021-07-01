using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPropeller2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 20, 0));
    }
}
