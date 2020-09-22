using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSelect : MonoBehaviour
{
    List<Button> charactersButtons;
    void Start()
    {
        GameObject[] characterButtons = GameObject.FindGameObjectsWithTag("characterSelectBtn");
        for (int i = 0; i < characterButtons.Length; i++)
        {
            charactersButtons.Add(characterButtons[i].GetComponent<Button>());
        }
    }

    public void characterSelected()
    {

    }
}
