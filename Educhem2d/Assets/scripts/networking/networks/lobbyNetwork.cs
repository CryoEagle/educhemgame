using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lobbyNetwork : MonoBehaviourPunCallbacks
{
    public InputField RoomCode;
    public GameObject ConnectBox;
    public Text ConnectingText;

    void Start()
    {
        print("Connecting to server...");
        PhotonNetwork.GameVersion = "0.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to master");
        PhotonNetwork.NickName = playerNetwork.Instance.NickName;

        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected, cause: " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby");
        ConnectBox.SetActive(true);
        ConnectingText.enabled = false;
    }

    public void ButtonClick_Join()
    {
        string code = RoomCode.text;
        if (code != "")
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 10;
            PhotonNetwork.JoinOrCreateRoom(code, roomOptions, TypedLobby.Default);
        }
    }
}
