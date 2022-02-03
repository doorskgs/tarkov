using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TarkovNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("Server Started!");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server Stopped!");
    }

    public GameObject playerFPSPrefab;
    

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //base.OnServerAddPlayer(conn);
        Transform startPos = GetStartPosition();
        GameObject player;
        
        player = startPos != null
            ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
            : Instantiate(playerPrefab);

        var identity = player.GetComponent<NetworkIdentity>();
        if (identity.isLocalPlayer)
        {
            // change player prefab to FPS player prefab
            Destroy(player);

            player = startPos != null
                ? Instantiate(playerFPSPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerFPSPrefab);
        }

        // instantiating a "Player" prefab gives it the name "Player(clone)"
        // => appending the connectionId is WAY more useful for debugging!
        player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
        NetworkServer.AddPlayerForConnection(conn, player);
    }


    //public override void OnClientConnect(NetworkConnection conn)
    //{
    //    Debug.Log("Connected to Server!");
    //}

    //public override void OnClientDisconnect(NetworkConnection conn)
    //{
    //    Debug.Log("Disconnected from Server!");
    //}
}
