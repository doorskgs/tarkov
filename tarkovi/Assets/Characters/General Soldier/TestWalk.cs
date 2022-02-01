using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestWalk : MonoBehaviour
{
    public Transform player;
    public Transform target;

    public List<Transform> points = new List<Transform>();
    NavMeshAgent agent;

    private int destPoint = 0;

    void Start()
    {
        //var wayPoints = GameObject.FindGameObjectsWithTag("Waypoint");
        //foreach (GameObject waypoint in wayPoints)
        //{
        //    points.Add(waypoint.transform);
        //}

        agent = player.GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Count;
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

}
