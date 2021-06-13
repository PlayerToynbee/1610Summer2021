using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    int x = 3;
    int y = 15;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The number " + x + " in addition to " + y + " is equal to " + (x + y) +".");
        Debug.Log("If you were to multiply " + x + " and " + y + " it would be equal to " + x * y + ".");
    }

}
