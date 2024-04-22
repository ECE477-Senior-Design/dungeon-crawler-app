using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerEditor : MonoBehaviour
{
    public GameObject nameInput;
    public GameObject raceInput;
    public GameObject classInput;
    public GameObject armorInput;
    public GameObject speedInput;
    public GameObject maxHPInput;
    public GameObject curHPInput;
    public GameObject strInput;
    public GameObject dexInput;
    public GameObject constInput;
    public GameObject intelInput;
    public GameObject wisInput;
    public GameObject charInput;
    public GameObject visibilityInput;
    public GameObject goldInput;
    public GameObject title;
    public GameObject initInput;
    public GameObject initSection;

    public BaseCharacter.Stats curStats;
    public GameObject infoFields;
    public GameObject statFields;

    public void OnEnable()
    {
        infoFields.SetActive(false);
        statFields.SetActive(false);

        SetLimit(nameInput, 10);
        SetLimit(armorInput, 2);
        SetLimit(speedInput, 2);
        SetLimit(maxHPInput, 2);
        SetLimit(curHPInput, 2);
        SetLimit(strInput, 2);
        SetLimit(dexInput, 2);
        SetLimit(constInput, 2);
        SetLimit(intelInput, 2);
        SetLimit(wisInput, 2);
        SetLimit(charInput, 2);
        SetLimit(visibilityInput, 2);
        SetLimit(goldInput, 2);
        SetLimit(initInput, 2);      
    }

    private void SetLimit(GameObject go, int limit)
    {
        go.GetComponent<TMP_InputField>().characterLimit = limit;
    }

    private string GetText(GameObject input)
    {
        return input.GetComponent<TMP_InputField>().text;
    }

    private void SetText(GameObject input, string text)
    {
        input.GetComponent<TMP_InputField>().text = text;
    }

    public BaseCharacter.Stats GetStats()
    {
        curStats.strength = GetText(strInput);
        curStats.dexterity = GetText(dexInput);
        curStats.constitution = GetText(constInput);
        curStats.intelligence = GetText(intelInput);
        curStats.wisdom = GetText(wisInput);
        curStats.charisma = GetText(charInput);
        curStats.maxHP = GetText(maxHPInput);
        curStats.curHP = GetText(curHPInput);
        curStats.speed = GetText(speedInput);
        curStats.armor = GetText(armorInput);
        curStats.visibility = GetText(visibilityInput);
        curStats.gold = GetText(goldInput);
        curStats.initiative = GetText(initInput);

        return curStats;
    }

    public int CheckHP()
    {
        int curHP = int.Parse(GetText(curHPInput));
        int maxHP = int.Parse(GetText(maxHPInput));
        if(curHP > maxHP)
        {
            return 1;
        }
        else if(maxHP <= 0)
        {
            return 2;
        }  
        return 0;
    }

    public void Clear()
    {
        SetText(nameInput, "");
        SetText(strInput, "0");
        SetText(dexInput, "0");
        SetText(constInput, "0");
        SetText(intelInput, "0");
        SetText(wisInput, "0");
        SetText(charInput, "0");
        SetText(maxHPInput, "0");
        SetText(curHPInput, "0");
        SetText(speedInput, "0");
        SetText(armorInput, "0");
        SetText(goldInput, "0");
        SetText(visibilityInput, "0");
        SetText(initInput, "0");


        if(title.GetComponent<TMP_Text>().text == "Player")
        {
            initSection.SetActive(false);
        }
        else
        {
            initSection.SetActive(true);
        }

    }

    public string GetName()
    {
        return GetText(nameInput);
    }

    public string GetRace()
    {
        int index = raceInput.GetComponent<TMP_Dropdown>().value;
        return raceInput.GetComponent<TMP_Dropdown>().options[index].text;
    }

    public string GetClass()
    {
        int index = classInput.GetComponent<TMP_Dropdown>().value;
        return classInput.GetComponent<TMP_Dropdown>().options[index].text;
    }

}
