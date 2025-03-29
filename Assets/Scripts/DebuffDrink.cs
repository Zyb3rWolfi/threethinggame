using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(fileName = "debuffDrink", menuName = "Objects/Create Debuff", order = 1)]
public class DebuffDrink : DrinkSerializable
{
    public float speedDebuff;
    public float catapultDecrease;
    public float stomachTickIncrease;
}
