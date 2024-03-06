using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class MapHex
{
    public int q;
    public int r;
    public string type;
    private int code;

    // private Dictionary<string, int> hexDefines;

    public MapHex(int _q, int _r, string _type)
    {
        q = _q;
        r = _r;
        type = _type;
    }

    public string getInfo()
    {
        string text = q.ToString() + r.ToString() + code.ToString();
        return text;
    }
}
