using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    [SerializeField] private DrinkSerializable equippedItem;
    
    public void SetEquippedItem(DrinkSerializable item)
    {
        equippedItem = item;
        TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = equippedItem.name;
    }
}
