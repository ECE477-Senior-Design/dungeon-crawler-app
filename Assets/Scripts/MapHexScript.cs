using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapHexScript : MonoBehaviour
{
    //attach to map hex prefab. This will be applied to every hex on the virtual map.
    private ManagerScript managerScript;
    private string defaultTag;
    private Color defaultColor;
    // Start is called before the first frame update
    void OnEnable()
    {
        managerScript = GameObject.Find("GameManager").GetComponent<ManagerScript>();
        defaultTag = managerScript.defaultHex.gameObject.tag;
        defaultColor = managerScript.defaultHex.GetComponent<Image>().color;
    }

    public void GetHex()
    {
        if(gameObject.tag == managerScript.HexType)
        {
            //allow player to unselect hex and reset it to floor if same hex type is still selected
            gameObject.tag = defaultTag;
            gameObject.GetComponent<Image>().color = defaultColor;
        }
        else
        {
            gameObject.tag = managerScript.HexType;
            gameObject.GetComponent<Image>().color = managerScript.HexColor;
        }

        Debug.Log(gameObject.tag);
    }
}
