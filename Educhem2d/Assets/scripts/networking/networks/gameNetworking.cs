using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameNetworking : MonoBehaviourPunCallbacks
{
    public Text roomCodeInfo;
    public Canvas RoomSelect;
    public Camera cameraMain;

    public GameObject playerPrefab;
    public GameObject[] spawnsRedTeam;
    public GameObject[] spawnsBlueTeam;

    private void Awake()
    {
        spawnsRedTeam = GameObject.FindGameObjectsWithTag("RedTeamSpawn");
        spawnsBlueTeam = GameObject.FindGameObjectsWithTag("BlueTeamSpawn");
    }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    private void Start()
    {
        roomCodeInfo.text = PhotonNetwork.CurrentRoom.Name;
    }

    void PlayerSelectedTeam(string team)
    {
        if (team == "red")
        {
            GameObject spawnRandomlySelected = spawnsRedTeam[Random.Range(0, spawnsRedTeam.Length)];
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(spawnRandomlySelected.transform.position.x, spawnRandomlySelected.transform.position.y), Quaternion.identity);
        }

        if(team == "blue")
        {
            GameObject spawnRandomlySelected = spawnsBlueTeam[Random.Range(0, spawnsBlueTeam.Length)];
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(spawnRandomlySelected.transform.position.x, spawnRandomlySelected.transform.position.y), Quaternion.identity);
        }

        RoomSelect.enabled = false;
        cameraMain.enabled = false;
        print(PhotonNetwork.LocalPlayer.CustomProperties["team"]);
    }

    public void Btn_RedTeamSelected()
    {
        PhotonNetwork.LocalPlayer.CustomProperties["team"] = "red";
        PlayerSelectedTeam("red");
    }

    public void Btn_BlueTeamSelected()
    {
        PhotonNetwork.LocalPlayer.CustomProperties["team"] = "blue";
        PlayerSelectedTeam("blue");
    }
}
