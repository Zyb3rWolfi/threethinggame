using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(fileName = "buffDrink", menuName = "Objects/Create Buff", order = 2)]
public class BuffDrink : DrinkSerializable
{
    public float speedBuff;
}
