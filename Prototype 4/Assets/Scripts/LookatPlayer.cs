using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Chomp");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);

    }
}