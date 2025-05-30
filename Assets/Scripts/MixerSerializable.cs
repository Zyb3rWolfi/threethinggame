using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "mixers", menuName = "Objects/Create Mix", order = 3)]
public class MixerSerializable : ScriptableObject
{
    public string name;
    public DebuffDrink alcohol;
    public BuffDrink mixer;
}
