using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharManager : MonoBehaviour
{
    // Start is called before the first frame update
    private MapManager mapManager;
    public GameObject playerEditor;
    private PlayerEditor editorScript;

    public List<BaseCharacter> playerList;
    public List<BaseCharacter> monsterList;
    public GameObject charPage;

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
        curChar = new BaseCharacter(type, editorScript.GetName(), editorScript.GetRace(), editorScript.GetClass(), editorScript.GetStats());
        if(curChar.type == 0)
        {
            playerList.Add(curChar);
        }
        else
        {
            monsterList.Add(curChar);
        }
    }

    public void CreateCharacter(bool player)
    {
        editorScript.infoFields.SetActive(true);
        editorScript.statFields.SetActive(true);
        type = player ? 0 : 1;
        editorScript.Clear();
    }
    
}
