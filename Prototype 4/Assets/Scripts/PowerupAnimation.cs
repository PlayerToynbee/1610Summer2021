using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupAnimation : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up, 90f * Time.deltaTime);
    }
}
