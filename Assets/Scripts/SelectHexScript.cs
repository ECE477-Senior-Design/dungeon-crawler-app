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
        SetColors();
    }

    public void OnPointerDown(PointerEventData data)
    {
        managerScript.curType = gameObject.tag;
        //Debug.Log(gameObject.tag);
    }

    void SetColors()
    {
        gameObject.GetComponent<Image>().color = Dictionaries.colorDict[gameObject.tag];
        Debug.Log(Dictionaries.colorDict[gameObject.tag]);
    }
}
