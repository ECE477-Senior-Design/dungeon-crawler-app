using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StaggerScript : MonoBehaviour
{
    MapHex tempHex;

    // Initializes all the hexes
    void Start()
    {
        tempHex = new MapHex(0, 0, "Floor");
        foreach(Transform row in transform)
        {
            string rowName = row.transform.name;
            string rowNum = rowName.Substring(1);
            int r = Convert.ToInt32(rowNum);
            int qStart = -(r / 2);
            int qOffset = 0;
        
            foreach(Transform hex in row)
            {
                tempHex.q = qStart + qOffset;
                tempHex.r = r;
                hex.GetComponent<MapHexScript>().thisHex = tempHex;
                qOffset++;
            }
        }
    }
}
