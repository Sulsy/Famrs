using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item 
{
    public static int TYPEFOOD = 1;
    public static int TYPEPLOW = 2;
    public static int TYPESHOVEl = 3;

    public string name;
    public string imgUrl;
    public int type;
    public int count;
    public int price;
    public int LvL;
    public float timeGrow;
    public float strength;



    public Item(string name,string imgUrl, int type, int count, int price, int LvL, float timeGrow,float strength=1)
    {
        this.name = name;
        this.imgUrl = imgUrl;
        this.type = type;
        this.count = count;
        this.price = price;
        this.LvL = LvL;
        this.timeGrow = timeGrow;
        this.strength=strength;
    }
}
