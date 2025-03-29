using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MixedDrinkManager : MonoBehaviour
{
    [SerializeField] MixerSerializable m_Mixer;

    public static Action<MixerSerializable> cokeAction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnEnable()
    {
        MixedDrinkManager.action += doSomething;
    }

    void doSomething(double value) {
    }
    */

    void DrinkCheck()
    {
        cokeAction?.Invoke(m_Mixer);
    }
}
