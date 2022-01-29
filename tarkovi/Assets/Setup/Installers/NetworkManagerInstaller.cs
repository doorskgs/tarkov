using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trk.Setup.Installers
{
    public class NetworkManagerInstaller : MonoBehaviour
    {
        private NetworkManager nw;

        void Awake()
        {
            nw = GetComponent<NetworkManager>();
        }

        public void Init()
        {
            // @TODO: port es lofasz
        }
    }
}