using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoops : MonoBehaviour
{
    int x = 1;
    // Start is called before the first frame update
    void Start()
    {
        while (x >= 1)
        {
            if (x != 21)
            {
                Debug.Log(x++);
            }
            else
            {
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
