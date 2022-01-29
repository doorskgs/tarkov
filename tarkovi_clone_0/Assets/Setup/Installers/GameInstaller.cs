using UnityEngine;


namespace Trk.Setup.Installers
{
    [DisallowMultipleComponent]
    public class GameInstaller : MonoBehaviour
    {
        public bool InjectObjects = true;

        public NetworkManagerInstaller nwInst;


        void OnEnable()
        {
            if (TryGetComponent(out nwInst) && nwInst.enabled)
            {
                nwInst.Init();

                //if (TryGetComponent(out fixInst) && fixInst.enabled)
                //    fixInst.Init(nwInst);
            }

            //if (TryGetComponent(out entInst) && entInst.enabled)
            //    entInst.Init();

            //if (/*TryGetComponent(out guiInst)*/ guiInst != null)
            //    guiInst.Init();

            //if (TryGetComponent(out debugInst) && debugInst.enabled)
            //    debugInst.Init();

            if (InjectObjects)
                InjectMonoBehaviours();
        }

        ///// <GameMessage>DataLoader</GameMessage>
        //public void __InstGameLoaded()
        //{
        //    if (nwInst != null && nwInst.enabled)
        //        if (fixInst != null && fixInst.enabled)
        //            fixInst.OnLoad();

        //    if (entInst != null && entInst.enabled)
        //        entInst.OnLoad();

        //    if (guiInst != null && guiInst.enabled)
        //        guiInst.OnLoad();

        //    if (debugInst != null && debugInst.enabled)
        //        debugInst.OnLoad();

        //    Destroy(this);
        //}

        void InjectMonoBehaviours()
        {
            // Inject DI instances to all scene objects
            var monos = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
            //DIInjector.PopulateAll(monos);
        }

#if UNITY_EDITOR
  
#endif
    }
}
