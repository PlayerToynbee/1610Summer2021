using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontal;

    public float vertical;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
         }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * horizontal);
        transform.Translate(Vector3.left * speed * Time.deltaTime * vertical);

    }
}
