using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class MapManager : MonoBehaviour
{
    //this script will hold all type variables
    //needs to be a monobehaviour to use OnEnable()

    public string curType;
    public Transform stagger1;
    public Transform stagger2;
    public bool held;

    private List<Transform> evenRows;
    private List<Transform> oddRows;
    private string textString;
    public GameObject mapPage;
    private CharManager charManager;

    public GameObject testHex1;
    public GameObject testHex2;

    public void OnEnable()
    {
        curType = "Floor";
        charManager = GetComponent<CharManager>();
        mapPage = GameObject.Find("MapPage");

        //get rows into two separate lists for easy access
        evenRows = new List<Transform>();
        oddRows = new List<Transform>();
    }

    public void switchToCharacter()
    {
        
        charManager.charPage.GetComponent<Canvas>().enabled = true;
        mapPage.GetComponent<Canvas>().enabled = false;
    }

    public void SendToText()
    {
        // C:\Users\grace\AppData\LocalLow\DefaultCompany\SeniorDesignApp
        string filepath = Application.persistentDataPath + "/HexData.txt";

        System.IO.File.WriteAllText(filepath, ""); //reset file

        Debug.Log("tag: " + testHex1.tag);
        Debug.Log("type: " + testHex1.GetComponent<MapHexScript>().thisHex.type);
        Debug.Log(testHex1.GetComponent<MapHexScript>().thisHex.q);
        Debug.Log(testHex1.GetComponent<MapHexScript>().thisHex.r);

        Debug.Log("tag: " + testHex2.tag);
        Debug.Log("type: " + testHex2.GetComponent<MapHexScript>().thisHex.type);
        Debug.Log(testHex2.GetComponent<MapHexScript>().thisHex.q);
        Debug.Log(testHex2.GetComponent<MapHexScript>().thisHex.r);


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
            var curRow0 = evenRows[i]; //row0, row2, row4 ... row14
            var curRow1 = oddRows[i]; //row1, row3, row5 ... row15
            foreach(Transform hexObject in curRow0)
            {
                textString = hexObject.GetComponent<MapHexScript>().GetTypeCode();
                System.IO.File.AppendAllText(filepath, textString);
            }
            foreach(Transform hexObject in curRow1)
            {
                textString = hexObject.GetComponent<MapHexScript>().GetTypeCode();
                System.IO.File.AppendAllText(filepath, textString);
            }
        }

        System.IO.File.AppendAllText(filepath, Environment.NewLine);

        foreach(BaseCharacter c in charManager.playerList)
        {
            System.IO.File.AppendAllText(filepath, c.PrintInfo() + Environment.NewLine);
        }

        foreach(BaseCharacter c in charManager.monsterList)
        {
            System.IO.File.AppendAllText(filepath, c.PrintInfo() + Environment.NewLine);
        }

        

        //print characters

        //get all characters from char manager
        //for each character in list, 

    }

}
