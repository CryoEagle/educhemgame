using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createRoom : MonoBehaviourPunCallbacks
{
    //[SerializeField]
    //private Text _roomName;
    //private Text RoomName
    //{
    //    get { return _roomName; }
    //}

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void OnClick_CreateRoom()
    {
        string guid = Guid.NewGuid().ToString().Substring(0, 8);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;

        if (PhotonNetwork.CreateRoom(guid, roomOptions))
        {
            print("Create room sent ok");
        } else
        {
            print("Failed sent room");
        }
    }

    public override void OnCreatedRoom()
    {
        print("Room created");
    }

    public override void OnJoinedRoom()
    {
        print("Joined room");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }
}
