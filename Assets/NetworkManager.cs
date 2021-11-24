using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        connectToServer();
    }
    void connectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("try to connect to server");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to server");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room 1",roomOptions,TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
        base.OnJoinedRoom();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("a player joined the room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
