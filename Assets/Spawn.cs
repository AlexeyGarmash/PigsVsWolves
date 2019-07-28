using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawn : NetworkBehaviour
{
    public GameObject Prefab;
    public Transform SpawnPoint;


    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            CmdSpawnMyCrap();
        }
    }
    [Command]
    void CmdSpawnMyCrap()
    {
        GameObject go =  Instantiate(Prefab, SpawnPoint);
        NetworkServer.Spawn(go);
    }
}
