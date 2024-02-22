using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;

public class ManagerScript : MonoBehaviour
{
    //this script will hold all type variables

    private string _curHexType;
    public GameObject defaultHex;
    public Transform stagger1;
    public Transform stagger2;
    public List<Transform> evenRows;
    public List<Transform> oddRows;
    public GameObject testHex;



    public string HexType
    {
        get{return _curHexType;}
        set{_curHexType = value;}
    }

    public Color HexColor{get; set;}

    public void OnEnable()
    {
        HexType = defaultHex.tag;
        HexColor = defaultHex.GetComponent<Image>().color;
    }

    public void SendToJson()
    {
        string textString = testHex.GetComponent<MapHexScript>().thisHex.q.ToString();
        //string jsonString = JsonUtility.ToJson(defaultHex.GetComponent<MapHexScript>().thisHex);
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
                textString = hexObject.GetComponent<MapHexScript>().thisHex.q.ToString();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
                textString = hexObject.GetComponent<MapHexScript>().thisHex.r.ToString();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
                textString = hexObject.GetComponent<MapHexScript>().thisHex.type.ToString();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
            }
            foreach(Transform hexObject in curRow1)
            {
                textString = hexObject.GetComponent<MapHexScript>().thisHex.q.ToString();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
                textString = hexObject.GetComponent<MapHexScript>().thisHex.r.ToString();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
                textString = hexObject.GetComponent<MapHexScript>().thisHex.type.ToString();
                System.IO.File.AppendAllText(Application.persistentDataPath + "/HexData.txt", textString);
            }
        }

    }

}
