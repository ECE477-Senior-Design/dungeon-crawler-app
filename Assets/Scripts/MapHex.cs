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
    public int row;
    public int column;

    public MapHex(int _q, int _r, string _type)
    {
        q = _q;
        r = _r;
        type = _type;
        row = r;
        column = q + r/2;
    }

    public string getInfo()
    {
        string text = q.ToString() + r.ToString() + code.ToString();
        return text;
    }
}
