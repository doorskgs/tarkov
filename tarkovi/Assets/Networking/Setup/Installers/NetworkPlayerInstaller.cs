using Mirror;
using System.Collections;
using UnityEngine;

namespace Assets.Networking.Setup.Installers
{
    /// <summary>
    /// Set up on Player prefab (NetworkIdentity)
    /// installs GUI and Camera
    /// </summary>
    public class NetworkPlayerInstaller : NetworkBehaviour
    {
        public Vector3 cameraOffset;
        public Quaternion cameraRotation;

        public override void OnStartLocalPlayer()
        {
            Debug.Log("NW Init");

            // Find camera
            var cam = Camera.main;
            if (cam == null)
                cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            var camTrans = cam.transform;

            if (cam == null)
            {
                Debug.LogError("Camera not found!");
                return;
            }

            // setup camera under player & set fix position
            camTrans.SetParent(transform, false);
            camTrans.localPosition = cameraOffset;
            camTrans.localRotation = cameraRotation;

            if (TryGetComponent(out FPSLookAround szem))
            {
                // @TODO: set up FPSLookaround
                //szem.cam = camTrans;
                szem.enabled = true;
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}