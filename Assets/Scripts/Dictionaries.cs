using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dictionaries : MonoBehaviour
{

    public static Dictionary <string, char> codeDict;
    public static Dictionary <string, Color> colorDict;
    public static Dictionary <string, string> raceDict;
    public static Dictionary <string, string> classDict;

    public static Color wallColor = new Color(87.0f/255.0f, 17.0f/255.0f, 115.0f/255.0f);
    public static Color floorColor = new Color(200.0f/255.0f, 200.0f/255.0f, 200.0f/255.0f);
    public static Color chestColor = new Color(255.0f/255.0f, 229.0f/255.0f, 63.0f/255.0f);
    public static Color playerColor = new Color(12.0f/255.0f, 123.0f/255.0f, 200.0f/255.0f);
    public static Color enemyColor = new Color(212.0f/255.0f, 19.0f/255.0f, 35.0f/255.0f);

    static Dictionaries()
    {
        codeDict = new Dictionary<string, char>{

            {"Floor", '8'},
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

        raceDict = new Dictionary<string, string>{
            {"Dragonborn", "0"},
            {"Dwarf", "1"},
            {"Elf", "2"},
            {"Gnome", "3"},
            {"Half Elf", "4"},
            {"Halfling", "5"},
            {"Half Orc", "6"},
            {"Human", "7"},
            {"Tiefling", "8"}
        };

        classDict = new Dictionary<string, string>{
            {"Fighter", "0"},
            {"Ranger", "1"}
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
