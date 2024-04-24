using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
    public TMP_Dropdown charDrop;

    private BaseCharacter curChar;
    private int type;
    private List<TMP_Dropdown.OptionData> options;

    void OnEnable()
    {
        mapManager = GetComponent<MapManager>();
        charPage.GetComponent<Canvas>().enabled = false;
        editorScript = playerEditor.GetComponent<PlayerEditor>();

        options = new List<TMP_Dropdown.OptionData>();
        charDrop.ClearOptions();
        playerList = new List<BaseCharacter>();
        monsterList = new List<BaseCharacter>();
    }

    public void SwitchToMap()
    {
        charPage.GetComponent<Canvas>().enabled = false;
        mapManager.mapPage.GetComponent<Canvas>().enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadCharacter()
    {
        string n = GetCurrentDropdown();
        foreach(BaseCharacter c in playerList)
        {
            if(c.GetName() == n)
            {
                editorScript.title.GetComponent<TMP_Text>().text = (c.type == 0) ? "Player" : "Monster";
                editorScript.SetStats(c.GetName(), c.GetClass(), c.GetRace(), c.GetStats());
                return;
            }
        }
        foreach(BaseCharacter c in monsterList)
        {
            if(c.GetName() == n)
            {
                editorScript.title.GetComponent<TMP_Text>().text = (c.type == 0) ? "Player" : "Monster";
                editorScript.SetStats(c.GetName(), c.GetClass(), c.GetRace(), c.GetStats());
                return;
            }
        }

        errorText.text = "Load Error";
    }

    public void SaveCharacter()
    {
        if(editorScript.GetName() == "")
        {
            errorText.text = "Character needs a name";
            return;
        }

        switch(editorScript.CheckHP())
        {
            case 0:
                break;
            case 1:
                errorText.text = "Current HP must be less than Max HP";
                return;
            case 2:
                errorText.text = "Max HP must be greater than 0";
                return;
        }

        if(CheckDropdown(editorScript.GetName()))
        {
            foreach(BaseCharacter c in playerList)
            {
                if(c.GetName() == editorScript.GetName())
                {
                    UpdateCharacter(c);
                    return;
                }
            }
            foreach(BaseCharacter c in monsterList)
            {
                if(c.GetName() == editorScript.GetName())
                {
                    UpdateCharacter(c);
                    return;
                }
            }
        }
        else
        {
            curChar = new BaseCharacter(type, editorScript.GetName(), editorScript.GetRace(), editorScript.GetClass(), editorScript.GetStats());
            options.Add(new TMP_Dropdown.OptionData(editorScript.GetName()));
            charDrop.AddOptions(options);
            options.Clear();
            
            if(curChar.type == 0)
            {
                playerList.Add(curChar);
            }
            else
            {
                monsterList.Add(curChar);
            }
        }
        errorText.text = "";
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

    private void UpdateCharacter(BaseCharacter c)
    {
        c.type = type;
        c.SetName(editorScript.GetName());
        c.SetRace(editorScript.GetRace());
        c.SetClass(editorScript.GetClass());
        c.myStats = editorScript.GetStats();
    }

    private bool CheckDropdown(string name)
    {
        foreach (TMP_Dropdown.OptionData option in charDrop.options)
        {
            if (option.text == name)
            {
                return true;
            }
        }
        return false;
    }

    private string GetCurrentDropdown()
    {
        int index = charDrop.value; // Get the index of the currently selected option
        string cur = charDrop.options[index].text; // Get the text of the selected option
        return cur;
    }

    public void DeleteCharacter()
    {

        BaseCharacter characterToRemove = null;

        foreach (BaseCharacter c in playerList)
        {
            if (c.GetName() == editorScript.GetName())
            {
                characterToRemove = c;
                break;
            }
        }

        if (characterToRemove != null)
        {
            playerList.Remove(characterToRemove);
            RemoveOption(characterToRemove.GetName());
            editorScript.Clear();
            return;
        }

        // Search monster list
        foreach (BaseCharacter c in monsterList)
        {
            if (c.GetName() == editorScript.GetName())
            {
                characterToRemove = c;
                break;
            }
        }

        if (characterToRemove != null)
        {
            monsterList.Remove(characterToRemove);
            RemoveOption(characterToRemove.GetName());
            editorScript.Clear();
        }        

    }

    private void RemoveOption(string name)
    {
        List<TMP_Dropdown.OptionData> options = charDrop.options;
        for(int i = 0; i < options.Count; i++)
        {
            if(options[i].text == name)
            {
                options.RemoveAt(i);
                break;
            }
        }
        charDrop.options = options;
        charDrop.RefreshShownValue();
    }
    
}


