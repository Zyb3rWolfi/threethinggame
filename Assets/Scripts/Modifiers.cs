using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "modifier", menuName = "Objects/Create Modifiers", order = 3)]

public class Modifiers : ScriptableObject
{
    public float speed;
    public float catapultForce;
    public bool triggerIncrease; 
}
                            