using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSelect : MonoBehaviour
{
    List<GameObject> charactersButtons = new List<GameObject>();
    public string CharacterSelected { get; set; }
    void Start()
    {
        GameObject[] characterButtons = GameObject.FindGameObjectsWithTag("characterSelectBtn");
        for (int i = 0; i < characterButtons.Length; i++)
        {
            charactersButtons.Add(characterButtons[i]);
        }
    }

    public void Btn_CharacterSelect(string character)
    {
        CharacterSelected = character;
        foreach(GameObject btn in charactersButtons)
        {
            Image imgComponent = btn.GetComponent<Image>();

            if(btn.name == character)
            {
                imgComponent.color = new Color32(250, 245, 177, 255);
            } else
            {
                imgComponent.color = Color.white;
            }
        }
    }
}
