using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSJump : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundChecker;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}