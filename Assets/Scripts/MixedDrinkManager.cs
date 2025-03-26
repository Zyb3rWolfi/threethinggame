using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class MixedDrinkManager : MonoBehaviour
{
    [SerializeField] MixerSerializable m_Mixer;

    public static Action<MixerSerializable> cokeAction;

    
    private void OnEnable()
    {
        MixedDrinkManager.cokeAction += DrinkMixer;
    }

    void DrinkMixer(MixerSerializable value) 
    {
        Debug.Log($"Drinking {value}");
    }
    

    void DrinkCheck()
    {
        cokeAction?.Invoke(m_Mixer);
    }
}
