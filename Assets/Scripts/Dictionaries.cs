using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dictionaries : MonoBehaviour
{

    public static Dictionary <string, char> codeDict;
    public static Dictionary <string, Color> colorDict;
    public static Dictionary <string, int> raceDict;
    public static Dictionary <string, int> classDict;

    public static Color wallColor = new Color(83.0f/255.0f, 5.0f/255.0f, 156.0f/255.0f);
    public static Color floorColor = new Color(200.0f/255.0f, 200.0f/255.0f, 200.0f/255.0f);
    public static Color chestColor = new Color(230.0f/255.0f, 218.0f/255.0f, 96.0f/255.0f);
    public static Color playerColor = new Color(12.0f/255.0f, 123.0f/255.0f, 200.0f/255.0f);
    public static Color enemyColor = new Color(212.0f/255.0f, 19.0f/255.0f, 35.0f/255.0f);

    static Dictionaries()
    {
        codeDict = new Dictionary<string, char>{

            {"Floor", '0'},
            {"Wall", '1'},
            {"Chest", '4'},
            {"Player", '2'},
            {"Enemy", '3'}
        };

        colorDict = new Dictionary<string, Color>{

            {"Floor", floorColor},
            {"Wall", wallColor},
            {"Chest", chestColor},
            {"Player", playerColor},
            {"Enemy", enemyColor}
        };

        raceDict = new Dictionary<string, int>{
            
        };

        classDict = new Dictionary<string, int>{

            {"Fighter", 0}
        };
    }

    public static char GetCode(string val)
    {
        return codeDict[val];
    }

    public static Color GetColor(string val)
    {
        return colorDict[val];
    }
}
