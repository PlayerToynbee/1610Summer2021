using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEachAndForLoopWithArrays : MonoBehaviour
{
    int[] num = { 5, 6, 75, 65, 55, 45, 35, 25, 15, 115 };
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Watch me make things complicated and change an array of random numbers to numbers 1 - 10.");
        for (int i = 1; i <= 10; i++)
        {
           num[i-1] = i;
        }
        foreach (int i in num)
         {
             Debug.Log(i);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
