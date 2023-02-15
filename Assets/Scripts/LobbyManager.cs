using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    [SerializeField]
    public Text playerName, roomName;
    [SerializeField]
    private Text nickname, status, room, players, role;
    
    public bool isChaser;

    int playerCount;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public GameObject player;

    public Button chaserButton;
    public Button survivorButton;
    public Button survivorButton2;
    public Button survivorButton3;
    public Button survivorButton4;

    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;
    private void Start()
    {
        status.text = "Connecting...";
        if (!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            nickname.text = "Hello, " + PhotonNetwork.NickName;
            room.text = "Room: " + PhotonNetwork.CurrentRoom.Name;
            players.text = "Players: " + PhotonNetwork.CurrentRoom.PlayerCount + " of " + PhotonNetwork.CurrentRoom.MaxPlayers;

            players.text += ":\n";
            Dictionary<int, Player> mydict = PhotonNetwork.CurrentRoom.Players;
            int i = 1;
            foreach (var item in mydict)
                players.text += string.Format("{0,2}. {1}\n", (i++), item.Value.NickName);

        }
        else if (PhotonNetwork.IsConnected)
        {
            nickname.text = "Type your name below and hit SET!";
            room.text = "Not yet in a room...";
            players.text = "Players: 0";
        }
        else
            nickname.text = room.text = players.text = "";


    }    // Update is called once per frame
    public void OnClickCreate()
    {
        PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 5 });

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Select your role");

        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Room Name; " + PhotonNetwork.CurrentRoom.Name;
       
        status.text = "Select your role";

        PhotonNetwork.Instantiate(player.name,
             new Vector3(Random.Range(-15, 15), 1, Random.Range(-15, 15)),
             Quaternion.Euler(0, Random.Range(-180, 180), 0)
             , 0);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= nextUpdateTime)
        {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    void UpdateRoomList(List<RoomInfo> list)
    {
        foreach (RoomItem item in roomItemsList)
        {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list)
        {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    public void JoinRoom(string roomName)
    {
        //playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        PhotonNetwork.JoinRoom(roomName);
    }

    public void OnClickSet()
    {
        PlayerPrefs.SetString("PlayerName", playerName.text);
        PhotonNetwork.NickName = playerName.text;
    }
    public void OnClickLeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        role.text = "Role";
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }
    public override void OnConnectedToMaster()
    {
        status.text = "Connected to Photon.";
        PhotonNetwork.JoinLobby();
        playerName.text = PlayerPrefs.GetString("PlayerName");
    }
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        status.text = newPlayer.NickName + " has just entered.";
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
    }
    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        status.text = otherPlayer.NickName + " has just left.";
        playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
    }



    public override void OnJoinRandomFailed (short returnCode, string message)
    {
        Debug.Log("Oops, tried to join a room and failed. Calling CreateRoom!");

        // failed to join a random room, so create a new one
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 5 });
    }


    public void OnClickChaser()
    {
        isChaser = true;
        role.text = "Role: Chaser";
        PlayerPrefs.SetString("Chaser", role.text);
        PlayerController.identity = 0;
    }

    public void OnClickSurvivor()
    {
        isChaser = false;
        role.text = "Role: Survivor";
        PlayerPrefs.SetString("Survivor", role.text);
        PlayerController.identity = 1;


    }
    public void OnClickSurvivor2()
    {
        isChaser = false;
        role.text = "Role: Survivor";
        PlayerPrefs.SetString("Survivor", role.text);
        PlayerController.identity = 2;


    }
    public void OnClickSurvivor3()
    {
        isChaser = false;
        role.text = "Role: Survivor";
        PlayerPrefs.SetString("Survivor", role.text);
        PlayerController.identity = 3;


    }
    public void OnClickSurvivor4()
    {
        isChaser = false;
        role.text = "Role: Survivor";
        PlayerPrefs.SetString("Survivor", role.text);
        PlayerController.identity = 4;

    }

    public void OnClickStart()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 1)
        {
            //if host 
            if (PhotonNetwork.IsMasterClient)
            {
                //Load game scene
                PhotonNetwork.LoadLevel("Game Scene");
                PhotonNetwork.AutomaticallySyncScene = true;

            }
            else
            {
                status.text = "Waiting for host";
            }

            //enables a 'waiting for host' panel

        }
       
    }
   
}
