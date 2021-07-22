using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyLookat : MonoBehaviour
{
    //public GameObject body;

    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = body.transform.position;
        transform.LookAt(camera.transform.position);

    }
}
