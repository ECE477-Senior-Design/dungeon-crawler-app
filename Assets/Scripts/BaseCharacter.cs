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
        public string gold;
        public string visibility;
        public string initiative;
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
        race = Dictionaries.raceDict[_r];
        charClass = Dictionaries.classDict[_c];
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
        return (name + "," + //0
        column.ToString() + "," //1
        + row.ToString() + "," //2
        + myStats.strength + "," //3
        + myStats.dexterity + "," //4
        + myStats.constitution + "," //5
        + myStats.intelligence + "," //6
        + myStats.wisdom + "," //7
        + myStats.charisma + "," //8
        + myStats.maxHP + "," //9
        + myStats.curHP + "," //10
        + myStats.armor + "," //11
        + myStats.initiative + "," //12, initiative
        + myStats.speed + "," //13
        + myStats.gold + "," //14
        + myStats.visibility + "," //15
        + race + "," //16
        + type.ToString() + "," //17
        + charClass); //18
    }

}
