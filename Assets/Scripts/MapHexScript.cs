using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine.EventSystems;



public class MapHexScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    //attach to map hex prefab. This will be applied to every hex on the virtual map.

    public MapHex thisHex;
    private MapManager manager;

    //instantiate map hexes as floor type. leave q and r as 0 for now.
    //q and r will be set during Start by the StaggerScript
    void OnEnable()
    {
        manager = GameObject.Find("GameManager").GetComponent<MapManager>();
        thisHex = new MapHex(0, 0, "Floor");
        gameObject.tag = thisHex.type;
    }

    //check for dragging
    public void OnPointerEnter(PointerEventData data)
    {
        if(manager.held) //check if mouse is held down
        {
            thisHex.type = manager.curType; //set this hex type to the selected type
            gameObject.tag = thisHex.type; //set tag for easier debugging in the editor
            GetComponent<Image>().color = Dictionaries.GetColor(manager.curType); //change the hex color accordingly
        }
    }

    //check for click
    public void OnPointerDown(PointerEventData data)
    {
        // Debug.Log("Manager:" + manager.curType);
        // Debug.Log("This Hex:" + thisHex.type);
        manager.held = true;
        thisHex.type = manager.curType;
        gameObject.tag = thisHex.type;
        GetComponent<Image>().color = Dictionaries.GetColor(manager.curType);
    }

    public void OnPointerUp(PointerEventData data)
    {
        manager.held = false;
    }

    public string GetTypeCode()
    {
        return Dictionaries.GetCode(thisHex.type).ToString();
    }

}
