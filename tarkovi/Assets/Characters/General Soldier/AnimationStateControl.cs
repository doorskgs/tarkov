using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveAnimationState
{
    // Legs
    ANIM_RUN,
    ANIM_SPRINT,
    ANIM_IDLE,
    ANIM_JUMP, 
    ANIM_CROUCH,
    ANIM_LIE,
}

public enum EmotionAnimState
{
    EMO_NONE = 0,
    EMO_CLAP = 1
}


public class AnimationStateControl : MonoBehaviour
{
    public bool controlMoveByVelocity = false;

    [Tooltip("Target Helper for aiming")]
    public Transform AimHelperTransform;
    public Transform WeaponSlotBaseTransform;
    float aimHelperFrontDistance;

    public Animator anim;

    public Vector3 AimDirection = Vector3.forward;


    void Awake()
    {
        if (anim == null)
            TryGetComponent(out anim);
        aimHelperFrontDistance = AimHelperTransform.position.z - WeaponSlotBaseTransform.position.z;
    }

    public void SetMoveAnimation(MoveAnimationState state)
    {
        // todo: solve it better
        switch(state)
        {
            case MoveAnimationState.ANIM_IDLE:
                anim.SetBool("isRunning", false);
                break;
            case MoveAnimationState.ANIM_RUN:
                anim.SetBool("isRunning", true);
                break;
        }
    }

    public void SetEmotion(EmotionAnimState state)
    {
        anim.SetInteger("emotion", (int)state);
    }

    private void LateUpdate()
    {
        // point laser towards direction
#if UNITY_EDITOR
        Debug.DrawRay(WeaponSlotBaseTransform.position, AimDirection * 1000f, Color.red);
#endif
        // put AimHelper T to direction, so that it drives TPS LookAround IK rig
        AimHelperTransform.position = WeaponSlotBaseTransform.position + AimDirection * aimHelperFrontDistance;
        // rotate player towards aim in Y axis
        //transform.rotation = aim



        if (!controlMoveByVelocity) return;

        // @todo: other stuff?
    }

    public void SetLookAt(Vector3 dir)
    {
        AimDirection = dir.normalized;
    }

    public void SetLookAt(Quaternion dir)
    {

    }

    public void SetLookAt(Transform target)
    {

    }
}
