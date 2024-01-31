using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    //this script will hold all type variables

    private string _curHexType;
    public GameObject defaultHex;

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

}
