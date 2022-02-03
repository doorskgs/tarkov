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

    [Tooltip("Top Spine bone")]
    public Transform SpineBoneSkeleton;

    public Animator anim;


    void Awake()
    {
        if (anim == null)
            TryGetComponent(out anim);
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
        if (!controlMoveByVelocity) return;

        
    }

    public void SetLookAt()
    {

    }
}
