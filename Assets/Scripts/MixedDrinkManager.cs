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
    private DebuffDrink debuff;
    private BuffDrink buff;

    public static Action<Modifiers> mixerSelected;

    void Start()
    {
        // buffs
        buff.speedBuff = modifiers.speed;
        buff.catapultIncrease = modifiers.catapultIncrease;
        buff.stomachTickDecrease = modifiers.stomachTickDecrease;

        // debuffs
        debuff.speedDebuff = modifiers.speed;
        debuff.catapultDecrease = modifiers.catapultDecrease;
        debuff.stomachTickIncrease = modifiers.stomachTickIncrease;

        mixerSelected?.Invoke(modifiers);
    }
}

