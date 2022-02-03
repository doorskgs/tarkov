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
    AnimationStateControl anim;

    private int destPoint = 0;
    bool stopped = false;

    private void Awake()
    {
        player.TryGetComponent(out agent);
        player.TryGetComponent(out anim);
    }

    void Start()
    {
        //var wayPoints = GameObject.FindGameObjectsWithTag("Waypoint");
        //foreach (GameObject waypoint in wayPoints)
        //{
        //    points.Add(waypoint.transform);
        //}

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
        {
            anim.SetMoveAnimation(MoveAnimationState.ANIM_IDLE);
            stopped = true;
            return;
        }

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Count;

        anim.SetMoveAnimation(MoveAnimationState.ANIM_RUN);
    }

    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

        if (!stopped)
        {
            if (Input.GetKey(KeyCode.H))
            {
                anim.SetEmotion(EmotionAnimState.EMO_CLAP);
            }
            else
            {
                anim.SetEmotion(EmotionAnimState.EMO_NONE);
            }
            //anim.SetLookAt(target.position);
        }
    }

}
