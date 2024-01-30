using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectHexScript : MonoBehaviour
{
    //attach to select hex prefab

    private ManagerScript managerScript;

    void OnEnable()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<ManagerScript>();
    }

    public void SetHex()
    {
        managerScript.HexType = gameObject.tag;
        managerScript.HexColor = gameObject.GetComponent<Image>().color;
        //Debug.Log(gameObject.tag);
    }
}
