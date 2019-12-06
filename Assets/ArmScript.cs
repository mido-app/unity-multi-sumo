using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{    
    public float tuppariPower = 50.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // this.rb = this.GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Arm");
        if (collision.gameObject.tag != "Player") return;
        var vector = collision.gameObject.transform.position - this.transform.position;
        var unitVector = vector / Vector3.Magnitude(vector);
        var speedVector = unitVector * tuppariPower;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(speedVector, ForceMode.Impulse);
    }
}
