using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyenemy : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    void Start()
        {
        rb =transform.parent.GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision collision)
        {
        //if (collision.gameObject == null)
        {
           
            rb.AddForce(Random.onUnitSphere * speed, ForceMode.Impulse); 
        }
        
        }
    

    void Update()
    {
        
    }
}
