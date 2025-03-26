using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(fileName = "debuffDrikn", menuName = "Objects/Create Debuff", order = 1)]
public class DebuffDrink : DrinkSerializable
{
    public float speedDebuff;
    public float stomachTickIncrease;
}
