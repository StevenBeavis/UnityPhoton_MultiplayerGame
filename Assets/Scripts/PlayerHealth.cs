using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerHealth : MonoBehaviourPunCallbacks
{
    PhotonView pv;
    public static float health = 100;

    private void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (pv.IsMine)
        {
            if (health <= 0)
            {
                pv.RPC("Die", RpcTarget.AllBuffered);
            }
        }
    }

    [PunRPC]
    void Die()
    {
        gameObject.SetActive(false);
    }
}
