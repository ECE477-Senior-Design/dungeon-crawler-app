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

    public void OnEnable()
    {
        curType = "Floor";
    }

    public void SendToText()
    {
        System.IO.File.WriteAllText(Application.persistentDataPath + "/HexData.txt", ""); //reset file

        //get rows into two separate lists for easy access
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
                textString = hexObject.GetComponent<MapHexScript>().thisHex.getInfo();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
            }
            foreach(Transform hexObject in curRow1)
            {
                textString = hexObject.GetComponent<MapHexScript>().thisHex.getInfo();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
            }
        }

    }

}
