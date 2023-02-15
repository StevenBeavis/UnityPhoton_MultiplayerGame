using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class EnemyAttack : MonoBehaviourPunCallbacks
{
    private PlayerHealth playerhealth;

    public static bool shooting;

    PhotonView pv;
    
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        
        if (pv.IsMine)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                pv.RPC("RPC_Attack", RpcTarget.AllBuffered);
            }
        }
    }
    
    [PunRPC]
    void RPC_Attack()
    {      
        PlayerHealth.health -= 50;
        Debug.Log("health = " + PlayerHealth.health);
    } 
}