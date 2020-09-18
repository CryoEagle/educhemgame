using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNetwork : MonoBehaviour
{
    public static playerNetwork Instance;
    public string NickName { get; private set; }

    private void Awake()
    {
        Instance = this;

        NickName = "Player#" + Random.Range(1000, 9999);
    }
}
