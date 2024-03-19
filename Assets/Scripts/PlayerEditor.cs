using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

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

    public BaseCharacter.Stats curStats;
    public GameObject infoFields;
    public GameObject statFields;

    public void OnEnable()
    {
        infoFields.SetActive(false);
        statFields.SetActive(false);
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

        return curStats;
    }

    public void Clear()
    {
        SetText(nameInput, "");
        SetText(raceInput, "");
        SetText(classInput, "");
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

    }

    public string GetName()
    {
        return GetText(nameInput);
    }

    public string GetRace()
    {
        return GetText(raceInput);
    }

    public string GetClass()
    {
        return GetText(classInput);
    }

}
