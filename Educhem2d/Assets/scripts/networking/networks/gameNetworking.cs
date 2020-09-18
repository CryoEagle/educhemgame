using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameNetworking : MonoBehaviour
{
    public Text roomCodeInfo;

    public GameObject playerPrefab;

    private void Awake()
    {
        
    }

    private void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(0,0), Quaternion.identity);
        roomCodeInfo.text = PhotonNetwork.CurrentRoom.Name;
    }
}
