using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditional : MonoBehaviour
{
    int x = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (x > 3)
        {
            Debug.Log("X is greater than 3");
        }
        else if (x < 3)
        {
            Debug.Log("X is less than 3");
        }
        else
        {
            Debug.Log("X is equal to 3");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
