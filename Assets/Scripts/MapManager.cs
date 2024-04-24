using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using System.IO.Ports;
using System.Threading;
using TMPro;

public class MapManager : MonoBehaviour
{
    //this script will hold all type variables
    //needs to be a monobehaviour to use OnEnable()

    public string curType;
    public Transform stagger1;
    public Transform stagger2;
    public bool held;
    public TMP_Text characterText;
    public TMP_Text selectText;
    public GameObject comInput;
    private int numSet = 0;

    private List<Transform> evenRows;
    private List<Transform> oddRows;
    private List<Transform> allRows;
    private char[] textString;
    public GameObject mapPage;
    private CharManager charManager;

    public bool setMode;
    public bool characterSet;
    public MapHex curHex;
    public Button floorButton;

    public void OnEnable()
    {
        curType = "Floor";
        selectText.text = "Floor";
        charManager = GetComponent<CharManager>();
        mapPage = GameObject.Find("MapPage");
        textString = new char[256];
        //get rows into two separate lists for easy access
        evenRows = new List<Transform>();
        oddRows = new List<Transform>();
        allRows = new List<Transform>();

        foreach(Transform row in stagger1)
        {
            evenRows.Add(row);
        }
        foreach(Transform row in stagger2)
        {
            oddRows.Add(row);
        }
        for(int i = 0; i < 8; i++)
        {
            allRows.Add(stagger1.GetChild(i));
            allRows.Add(stagger2.GetChild(i));
        }
    }

    public void switchToCharacter()
    {  
        charManager.charPage.GetComponent<Canvas>().enabled = true;
        mapPage.GetComponent<Canvas>().enabled = false;
        StopAllCoroutines();
    }

    public void ClearMap()
    {
        //tempHex = new MapHex(0, 0, "Floor");
        foreach(Transform row in stagger1)
        {      
            foreach(Transform hex in row)
            {
                hex.GetComponent<MapHexScript>().thisHex.type = "Floor";
                hex.GetComponent<MapHexScript>().gameObject.tag = "Floor";
                hex.GetComponent<MapHexScript>().gameObject.GetComponent<Image>().color = Dictionaries.GetColor("Floor");
            }
        }

        foreach(Transform row in stagger2)
        {      
            foreach(Transform hex in row)
            {
                hex.GetComponent<MapHexScript>().thisHex.type = "Floor";
                hex.GetComponent<MapHexScript>().gameObject.tag = "Floor";
                hex.GetComponent<MapHexScript>().gameObject.GetComponent<Image>().color = Dictionaries.GetColor("Floor");
            }
        }
    }

    public void SetCharacters()
    {
        if((charManager.playerList.Count == 0) && (charManager.monsterList.Count == 0))
        {
            characterText.text = "No Characters Created";
            return;
        }
        if(numSet == 0)
        {
            numSet++;
        }
        else
        {
            foreach(BaseCharacter c in charManager.playerList)
            {
                var hexUI = allRows[c.row].GetChild(c.column); //get the location of the character
                if(hexUI.GetComponent<MapHexScript>().thisHex.type == "Floor")
                {
                    break;
                }
                hexUI.GetComponent<MapHexScript>().thisHex.type = "Floor";
                hexUI.GetComponent<MapHexScript>().gameObject.tag = "Floor";
                hexUI.GetComponent<MapHexScript>().GetComponent<Image>().color = Dictionaries.GetColor("Floor");     
            }
            foreach(BaseCharacter c in charManager.monsterList)
            {
                var hexUI = allRows[c.row].GetChild(c.column);
                if(hexUI.GetComponent<MapHexScript>().thisHex.type == "Floor")
                {
                    break;
                }
                hexUI.GetComponent<MapHexScript>().thisHex.type = "Floor";
                hexUI.GetComponent<MapHexScript>().gameObject.tag = "Floor";
                hexUI.GetComponent<MapHexScript>().GetComponent<Image>().color = Dictionaries.GetColor("Floor");     
            }
        }
        StartCoroutine(WaitForSet());
    }

    public IEnumerator WaitForSet()
    {
        setMode = true;

        if(charManager.playerList.Count != 0)
        {
            curType = "Player";
            foreach(BaseCharacter c in charManager.playerList)
            {
                characterText.text = "Place " + c.GetName() + "\non the map";

                characterSet = false;
                while(characterSet == false)
                {
                    yield return null;
                }
                c.row = curHex.row;
                c.column = curHex.column;
            }
        }

        if(charManager.monsterList.Count != 0)
        {
            curType = "Enemy";
            foreach(BaseCharacter c in charManager.monsterList)
            {
                characterText.text = "Place " + c.GetName() + "\non the map";
                characterSet = false;
                while(characterSet == false)
                {
                    yield return null;
                }
                c.row = curHex.row;
                c.column = curHex.column;
            }
        }
        characterText.text = "All Characters Placed";
        selectText.text = "Floor";
        floorButton.Select();
        curType = "Floor";
        setMode = false;
    }

    public void SentToPort()
    {
        string num = comInput.GetComponent<TMP_InputField>().text;
        string port = "COM" + num;
        Debug.Log(port);
        SerialPort _serialPort = new SerialPort(port, 19200, Parity.None, 8, StopBits.One);
        _serialPort.WriteTimeout = 2000;
        _serialPort.Handshake = Handshake.None;

        _serialPort.Open(); //open the port

        int place = 0;

        for(int i = 0; i < 8; i++)
        {
            var curRow0 = evenRows[i]; //row0, row2, row4 ... row14
            var curRow1 = oddRows[i]; //row1, row3, row5 ... row15
            foreach(Transform hexObject in curRow0)
            {
                textString[place] = hexObject.GetComponent<MapHexScript>().GetTypeCode();
                place++;
            }
            foreach(Transform hexObject in curRow1)
            {
                textString[place] = hexObject.GetComponent<MapHexScript>().GetTypeCode();
                place++;
            }
        }

        _serialPort.Write(textString, 0, 256); //send map to serial port
        
        if(charManager.playerList.Count != 0)
        {
            foreach(BaseCharacter c in charManager.playerList)
            {
                _serialPort.Write(c.PrintInfo() + "\n");
                Debug.Log(c.PrintInfo());
            }
        }

        if(charManager.monsterList.Count != 0)
        {
            foreach(BaseCharacter c in charManager.monsterList)
            {
                _serialPort.Write(c.PrintInfo() + "\n");
                Debug.Log(c.PrintInfo());
            }
        }

        _serialPort.Close();
    }

}
