using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "player-data", menuName = "Player/Create Player Data", order = 3)]

public class PlayerData : ScriptableObject
{
    public string playerName;
    public DrinkSerializable[] unlockedDrinks;

    public BuffDrink SelectedBuffDrink;
    public DebuffDrink SelectedDebuffDrink;
}
