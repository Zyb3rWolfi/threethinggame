using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DrinkType
{
    Buff,
    Debuff
}
public class DrinkSerializable : ScriptableObject
{
    public string name;
    public int cost; 
    public DrinkType type;
}