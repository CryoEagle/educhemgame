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

    private void Awake()
    {
        spawnsRedTeam = GameObject.FindGameObjectsWithTag("RedTeamSpawn");
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

    }
}
