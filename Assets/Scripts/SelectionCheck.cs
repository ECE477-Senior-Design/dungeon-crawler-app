using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionCheck : MonoBehaviour
{

    private GameObject curObj;
    //attach this to an OnClick() Event to return the button to this script
    public void SetSelection(Button thisButton)
    {
        curObj = EventSystem.current.currentSelectedGameObject;
        curObj = curObj.transform.parent.gameObject;
    }

}
