using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter
{
    //BaseCharacter will cover all traits shared by both players and enemies in the game
    
    public struct Stats
    {
        public string strength;
        public string dexterity;
        public string constitution; //constitution
        public string intelligence; //intelligence
        public string wisdom;
        public string charisma;
        public string maxHP;
        public string curHP;
        public string speed;
        public string armor;
    }

    public int type;
    public int row;
    public int column;
    public Stats myStats;
    private string name;
    private string race;
    private string charClass;


    public BaseCharacter(int _type, string _n, string _r, string _c, Stats newStats)
    {
        type = _type;
        name = _n;
        race = _r;
        charClass = _c;
        myStats = newStats;
        row = 0;
        column = 0;
    }

    public string GetName()
    {
        return name;
    }

    public string GetRace()
    {
        return race;
    }

    public string GetClass()
    {
        return charClass;
    }

    public string PrintInfo()
    {
        return (name + "," + column.ToString() + "," + row.ToString() + "," + myStats.strength + "," + myStats.dexterity + "," + myStats.constitution + "," + myStats.intelligence + "," + myStats.wisdom + "," + myStats.charisma + "," + myStats.maxHP + "," + myStats.curHP + "," + myStats.armor + "," + "0," + myStats.speed);

    }

}
