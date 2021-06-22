using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    int x = 3;
    // Start is called before the first frame update
    void Start()
    {
        switch(x)
        {
            case 1:
                Debug.Log("This is the number 1");
                break;
            case 2:
                Debug.Log("This is the number 2");
                break;
            case 3:
                Debug.Log("This is the number 3");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
