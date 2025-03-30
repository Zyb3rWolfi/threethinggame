using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.Rendering;
using UnityEngine;

public class MixedDrinkManager : MonoBehaviour
{
    [SerializeField] private Modifiers modifiers;
    [SerializeField] private DebuffDrink debuff;
    [SerializeField] private BuffDrink buff;

    public static Action<Modifiers> mixerSelected;

    public void OnStartPress()
    {
        modifiers.speed = buff.speedBuff;
        modifiers.catapultForce = buff.forceBuff;        
        modifiers.triggerIncrease = buff.triggerBuff;
        
        mixerSelected?.Invoke(modifiers);
    }
}

