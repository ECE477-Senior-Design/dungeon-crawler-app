using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectHexScript : MonoBehaviour, IPointerDownHandler
{
    //attach to select hex prefab

    private MapManager managerScript;

    void OnEnable()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<MapManager>();
        setColor();
    }

    public void OnPointerDown(PointerEventData data)
    {
        managerScript.curType = gameObject.tag;
        //Debug.Log(gameObject.tag);
    }

    void setColor()
    {
        Dictionaries.colorDict[gameObject.tag] = gameObject.GetComponent<Image>().color;
    }
}
