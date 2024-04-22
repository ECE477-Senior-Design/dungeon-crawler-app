using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharManager : MonoBehaviour
{
    // Start is called before the first frame update
    private MapManager mapManager;
    public GameObject playerEditor;
    private PlayerEditor editorScript;

    public List<BaseCharacter> playerList;
    public List<BaseCharacter> monsterList;
    public GameObject charPage;
    public TMP_Text errorText;

    private BaseCharacter curChar;
    private int type;

    void OnEnable()
    {
        mapManager = GetComponent<MapManager>();
        charPage.GetComponent<Canvas>().enabled = false;
        editorScript = playerEditor.GetComponent<PlayerEditor>();
        playerList = new List<BaseCharacter>();
        monsterList = new List<BaseCharacter>();
    }

    public void SwitchToMap()
    {
        charPage.GetComponent<Canvas>().enabled = false;
        mapManager.mapPage.GetComponent<Canvas>().enabled = true;
        
    }

    public void SaveCharacter()
    {
        int check = 0;
        if(editorScript.GetName() == "")
        {
            errorText.text = "Character needs a name";
            return;
        }

        check = editorScript.CheckHP();
        if(check != 0)
        {
            if(check == 1)
            {
                errorText.text = "Current HP must be less than Max HP";
            }
            else if(check == 2)
            {
                errorText.text = "Max HP must be greater than 0";
            }
            return;
        }

        curChar = new BaseCharacter(type, editorScript.GetName(), editorScript.GetRace(), editorScript.GetClass(), editorScript.GetStats());
        if(curChar.type == 0)
        {
            playerList.Add(curChar);
        }
        else
        {
            monsterList.Add(curChar);
        }
        Debug.Log(curChar.PrintInfo());
    }

    public void CreateCharacter(bool player)
    {
        editorScript.infoFields.SetActive(true);
        editorScript.statFields.SetActive(true);
        type = player ? 0 : 1;
        editorScript.title.GetComponent<TMP_Text>().text = (type == 0) ? "Player" : "Monster";
        editorScript.Clear();
    }
    
}
