using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallAnimator : MonoBehaviour
{
    public Transform target;


    void Awake()
    {
    }

    void LateUpdate()
    {
        transform.LookAt(target, Vector3.up);
        Debug.DrawRay(transform.position, transform.forward * (target.position - transform.position).magnitude, Color.cyan);

        //transform.localRotation = transform.parent.parent.rotation;
    }
}
