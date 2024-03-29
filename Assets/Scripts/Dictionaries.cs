using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dictionaries : MonoBehaviour
{

    public static Dictionary <string, int> codeDict;
    public static Dictionary <string, Color> colorDict;
    public static Dictionary <string, int> raceDict;
    public static Dictionary <string, int> classDict;

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

        raceDict = new Dictionary<string, int>{
            
        };

        classDict = new Dictionary<string, int>{

            {"Fighter", 0}
        };
    }

    public static int GetCode(string val)
    {
        return codeDict[val];
    }

    public static Color GetColor(string val)
    {
        return colorDict[val];
    }
}
