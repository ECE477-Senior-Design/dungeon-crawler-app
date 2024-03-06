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
        Debug.Log("This Hex:" + thisHex.type);
        Debug.Log("Manager: " + manager.curType);
        Debug.Log(manager.held);
        if(manager.held)
        {
            thisHex.type = manager.curType;
            gameObject.tag = thisHex.type;
            GetComponent<Image>().color = Dictionaries.getColor(manager.curType);
        }
    }

    //check for click
    public void OnPointerDown(PointerEventData data)
    {
        // Debug.Log("Manager:" + manager.curType);
        // Debug.Log("This Hex:" + thisHex.type);
        manager.held = true;
        Debug.Log(manager.held);
        thisHex.type = manager.curType;
        gameObject.tag = thisHex.type;
        GetComponent<Image>().color = Dictionaries.getColor(manager.curType);
    }

    public void OnPointerUp(PointerEventData data)
    {
        manager.held = false;
        // foreach(MapHex hex in manager.selection)
        // {
        //     Debug.Log("changed");
        //     hex.type = manager.curType;
        //     gameObject.tag = manager.curType;
        // }
        // Debug.Log("Clear");
        // manager.selection.Clear();
    }

}
