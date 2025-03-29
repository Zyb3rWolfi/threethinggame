using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PubScriptable", menuName = "ScriptableObjects/PubScriptable", order = 1)]
public class PubScriptable : ScriptableObject
{
    public GameObject[] Pubs;
}
