using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectHexScript : MonoBehaviour, IPointerDownHandler
{
    //attach to select hex prefab

    private MapManager managerScript;
    private int selected;

    void OnEnable()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<MapManager>();
        SetColors();
    }

    // void Update()
    // {
    //     if(managerScript.curType == gameObject.tag)
    //     {
    //         GetComponent<Button>().Select();
    //     }
    // }

    public void OnPointerDown(PointerEventData data)
    {
        managerScript.curType = gameObject.tag;
        managerScript.selectText.text = gameObject.tag;
    }

    void SetColors()
    {
        gameObject.GetComponent<Image>().color = Dictionaries.colorDict[gameObject.tag];
        //Debug.Log(Dictionaries.colorDict[gameObject.tag]);
    }
}
