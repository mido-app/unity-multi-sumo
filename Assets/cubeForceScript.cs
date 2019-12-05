using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeForceScript : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        float x =  Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        rb.AddForce(x , 0 , z );
    }
}
