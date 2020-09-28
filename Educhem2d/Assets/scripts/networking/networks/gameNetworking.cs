using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class gameNetworking : MonoBehaviourPunCallbacks
{
    public Text roomCodeInfo;
    public Canvas RoomSelect;
    public Camera cameraMain;

    public GameObject playerPrefab;
    GameObject[] spawnsRedTeam;
    GameObject[] spawnsBlueTeam;
    public characterSelect characterSelectScript;
    public GameObject youDontSelectedTeam;

    public Button redTeamButton;
    public Button blueTeamButton;

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
        RoomSelect.enabled = true;
        roomCodeInfo.text = PhotonNetwork.CurrentRoom.Name;
    }

    void CharacterNotSelectedPopUp()
    {
        youDontSelectedTeam.gameObject.SetActive(true);
    }

    void PlayerSelectedTeam(string team)
    {
        string characterToSpawn = "";
        if(characterSelectScript.CharacterSelected == null)
        {
            characterToSpawn = "jetpackman";
        } else
        {
            characterToSpawn = characterSelectScript.CharacterSelected;
        }

        if (team == "red")
        {
            GameObject spawnRandomlySelected = spawnsRedTeam[Random.Range(0, spawnsRedTeam.Length)];
            PhotonNetwork.Instantiate(characterToSpawn, new Vector2(spawnRandomlySelected.transform.position.x, spawnRandomlySelected.transform.position.y), Quaternion.identity);
        }

        if(team == "blue")
        {
            GameObject spawnRandomlySelected = spawnsBlueTeam[Random.Range(0, spawnsBlueTeam.Length)];
            PhotonNetwork.Instantiate(characterToSpawn, new Vector2(spawnRandomlySelected.transform.position.x, spawnRandomlySelected.transform.position.y), Quaternion.identity);
        }

        RoomSelect.enabled = false;
        cameraMain.enabled = false;
        print(PhotonNetwork.LocalPlayer.CustomProperties["team"]);
        redTeamButton.enabled = false;
        blueTeamButton.enabled = false;
    }

    public void Btn_RedTeamSelected()
    {
        if(characterSelectScript.CharacterSelected == null)
        {
            CharacterNotSelectedPopUp();
            return;
        }

        PhotonNetwork.LocalPlayer.CustomProperties["team"] = "red";
        PlayerSelectedTeam("red");
    }

    public void Btn_BlueTeamSelected()
    {
        if (characterSelectScript.CharacterSelected == null)
        {
            CharacterNotSelectedPopUp();
            return;
        }

        PhotonNetwork.LocalPlayer.CustomProperties["team"] = "blue";
        PlayerSelectedTeam("blue");
    }
}
