using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public float bounceForce = 10f; //force of the bounce
    public Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision other)
    {
        rigidbody.AddForce (transform.up * bounceForce); //make it bounce
    }
}
