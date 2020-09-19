using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameNetworking : MonoBehaviourPunCallbacks
{
    public Text roomCodeInfo;

    public GameObject playerPrefab;
    public GameObject[] spawns;

    private void Awake()
    {
        spawns = GameObject.FindGameObjectsWithTag("RedTeamSpawn");
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
        GameObject spawnRandomlySelected = spawns[Random.Range(0, spawns.Length)];
        PhotonNetwork.Instantiate(playerPrefab.name, new Vector2(spawnRandomlySelected.transform.position.x, spawnRandomlySelected.transform.position.y), Quaternion.identity);

        roomCodeInfo.text = PhotonNetwork.CurrentRoom.Name;
    }
}
