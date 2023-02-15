using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public GameObject chaserPrefab;
    public GameObject playerPrefab;
    public GameObject playerPrefab2;
    public GameObject playerPrefab3;
    public GameObject playerPrefab4;
    

    public Transform[] playerSpawn;
    Player[] allPlayers;
    public Transform chaserSpawn;
    //int number = 0;
    
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        if (PlayerController.identity == 0)
        {
            GameObject myplayerGO = (GameObject)PhotonNetwork.Instantiate(this.chaserPrefab.name, chaserSpawn.position, Quaternion.identity);
            myplayerGO.GetComponent<PlayerController>().enabled = true;
            myplayerGO.GetComponent<EnemyAttack>().enabled = true;
            myplayerGO.transform.Find("Camera").gameObject.SetActive(true);
        }
        /*
        allPlayers = PhotonNetwork.PlayerList;
        foreach (Player p in allPlayers)
        */
        
        if (PlayerController.identity == 1)
        {
            SpawnPlayer();
            //number++;
        }
        if (PlayerController.identity == 2)
        {
            SpawnPlayer2();
            //number++;
        }
        if (PlayerController.identity == 3)
        {
            SpawnPlayer3();
            //number++;
        }
        if (PlayerController.identity == 4)
        {
            SpawnPlayer4();
            //number++;
        }

        
    }
    void SpawnPlayer()
    {
        GameObject myplayerGO = (GameObject)PhotonNetwork.Instantiate(this.playerPrefab.name, playerSpawn[0].position, Quaternion.identity);
        myplayerGO.GetComponent<PlayerController>().enabled = true;
        myplayerGO.transform.Find("Camera").gameObject.SetActive(true);

        
    }
    void SpawnPlayer2()
    {
        GameObject myplayerGO = (GameObject)PhotonNetwork.Instantiate(this.playerPrefab2.name, playerSpawn[1].position, Quaternion.identity);
        myplayerGO.GetComponent<PlayerController>().enabled = true;
        myplayerGO.transform.Find("Camera").gameObject.SetActive(true);
    }
    void SpawnPlayer3()
    {
        GameObject myplayerGO = (GameObject)PhotonNetwork.Instantiate(this.playerPrefab3.name, playerSpawn[2].position, Quaternion.identity);
        myplayerGO.GetComponent<PlayerController>().enabled = true;
        myplayerGO.transform.Find("Camera").gameObject.SetActive(true);
    }
    void SpawnPlayer4()
    {
        GameObject myplayerGO = (GameObject)PhotonNetwork.Instantiate(this.playerPrefab4.name, playerSpawn[3].position, Quaternion.identity);
        myplayerGO.GetComponent<PlayerController>().enabled = true;
        myplayerGO.transform.Find("Camera").gameObject.SetActive(true);
    }
    void Update()
    {
        
        
    }

}
