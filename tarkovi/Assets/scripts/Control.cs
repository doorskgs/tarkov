using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Control : MonoBehaviour
{
  public float jumpForce = 20f; //how much force you want when jumping
    public bool onGround;

    Rigidbody m_Rigidbody;
    Animator animator;
    public float m_Speed = 5f;

    private void Awake()
    {
        onGround = true;
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    { Vector3 veel = Vector3.zero;
        


        if (Input.GetKeyDown(KeyCode.Space) && onGround == true)
        {
            //adds force to player on the y axis by using the flaot set for the variable jumpForce. Causes the player to jump
            m_Rigidbody.AddForce(Vector3.up *m_Rigidbody.mass * jumpForce, ForceMode.Impulse);

            //says the player is no longer on the ground
            onGround = false;

        }
        Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        veel = transform.forward * m_Input.z * m_Speed;
        veel.y=m_Rigidbody.velocity.y;
        m_Rigidbody.velocity = veel;
        

        //Quaternion dir = transform.rotation.y;

        // mozgas sebesseg:

        //m_Rigidbody.MovePosition(transform.position + m_Input * );

        // animacio:
        animator.SetBool("isrunning", m_Input.sqrMagnitude > 0);
    }
    void OnCollisionEnter(Collision other)
    {
        //checks if collider is tagged "ground"
        if (other.gameObject.CompareTag("ground"))
        {
            //if the collider is tagged "ground", sets onGround boolean to true
            onGround = true;
        }
    }
}