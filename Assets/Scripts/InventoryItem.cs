using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] DrinkSerializable drink;
    [SerializeField] TextMeshProUGUI text;
    
    public static Action<DrinkSerializable> OnDrinkAdded;
    
    public void OnButtonPress()
    {
        OnDrinkAdded?.Invoke(drink);
    }

    public void SetDrink(DrinkSerializable drink_selected)
    {
        drink = drink_selected;
        text.text = drink.name;
    }
}
