using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundChecker;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask groundLayer;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool Ground()
    {
        //Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer);

        return Mathf.Abs(rb.velocity.y - 0) < 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Ground())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}