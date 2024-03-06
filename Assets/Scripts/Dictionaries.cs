using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dictionaries : MonoBehaviour
{

    public static Dictionary <string, int> codeDict;
    public static Dictionary <string, Color> colorDict;

    static Dictionaries()
    {
        codeDict = new Dictionary<string, int>{

            {"Floor", 0},
            {"Wall", 1},
            {"Chest", 2},
            {"Player", 3},
            {"Enemy", 4}
        };

        colorDict = new Dictionary<string, Color>{

            {"Floor", Color.white},
            {"Wall", Color.white},
            {"Chest", Color.white},
            {"Player", Color.white},
            {"Enemy", Color.white}
        };
    }

    public static int getCode(string val)
    {
        return codeDict[val];
    }

    public static Color getColor(string val)
    {
        return colorDict[val];
    }
}
