using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerDataScriptable", order = 1)]
public class PlayerDataScriptable : ScriptableObject
{
    [Header("Player Data")]
    public string PlayerName;
    public int PubNumber;
    public int Money;
    [Header("List of Unlocked Buff and Debuff Drinks")]
    public BuffDrink[] UnlockedBuffDrinks;
    public DebuffDrink[] UnlockedDebuffDrinks;
    [Header("List of Mixers (Drinks get better as you go down the list)")]
    public MixerSerializable[] Mixers;
}
