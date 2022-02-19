
using UnityEngine;

public class EasyFPSNetworkIdentityHandler : MonoBehaviour
{
#if UNITY_EDITOR
    [Header("Body Double")]
    [Tooltip("Add this object to copy the FPS animations")]
    public AnimationStateControl BodyDouble;
    public Vector3 BodyDoubleOffset = Vector3.left * 200f;

    Rigidbody doubleRb;
    Rigidbody myRb;
#endif


    IAimProvider gun;
    GunInventory inv;
    PlayerMovementScript move;

    private void Awake()
    {
        TryGetComponent(out inv);
        TryGetComponent(out move);
        TryGetComponent(out myRb);

#if UNITY_EDITOR
        if (BodyDouble != null)
        {
            BodyDouble.TryGetComponent(out doubleRb);

            // freeze RB so that it can be controlledf rom this script
            doubleRb.isKinematic = true;
        }
#endif
        //gun.AimDirection
    }

    private void LateUpdate()
    {
#if UNITY_EDITOR
        if (gun != null)
        {
            Debug.DrawRay(gun.AimDirection.origin, gun.AimDirection.direction * 1500f, Color.red);


            if (BodyDouble != null)
            {
                //BodyDouble.transform.position = transform.position + BodyDoubleOffset;
                //doubleRb.position = myRb.position;
                //doubleRb.velocity = Vector3.zero;

                // animate double
                BodyDouble.SetMoveAnimation(move.currentSpeed > 0.01f ? MoveAnimationState.ANIM_RUN : MoveAnimationState.ANIM_IDLE);
                BodyDouble.SetLookAt(gun.AimDirection.direction);
            }
        }
#endif
    }

    /// <GameMessage>GunInventory</GameMessage>
    public void __OnSwitchedGun(GameObject gunObj)
    {
        gunObj.TryGetComponent(out gun);

        if (gun == null)
        {
            Debug.LogError("Gun GameObject does not have IAimProvider (GunScript)");
        }
    }
}
