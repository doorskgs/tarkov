using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [Header("Raycast")]
    public float maxRayDist = 1500f;
    public string[] layers = new string[] {
            "enemy",
            "soldiers",
        };
    Camera cam;
    int draggableMask;
    int groundMask;

    void Start()
    {
        cam = Camera.main;
        draggableMask = LayerMask.GetMask(layers);
        groundMask = LayerMask.GetMask("ground");

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            Ray ray = new Ray(transform.position, cam.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, maxRayDist, draggableMask))
            {
                Debug.DrawRay(ray.origin, ray.direction*1000, Color.red,5);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction*1000, Color.blue,2); 
            }
         }   
           
        }
    
    }   
    

