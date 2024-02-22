using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaggerScript : MonoBehaviour
{
    MapHexScript hexScript;
    // Start is called before the first frame update
    void OnEnable()
    {
        foreach(Transform row in transform)
        {
            string rowName = row.transform.name;
            string rowNum = rowName.Substring(1);
            int r = Convert.ToInt32(rowNum);
            int qStart = -(r / 2);
            int qOffset = 0;
        
            foreach(Transform hex in row)
            {
                hexScript = hex.GetComponent<MapHexScript>();
                hexScript.setQ = qStart + qOffset;
                hexScript.setR = r;
                qOffset++;
            }
        }
    }
}
