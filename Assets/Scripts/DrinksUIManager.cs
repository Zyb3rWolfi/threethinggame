using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrinksUIManager : MonoBehaviour
{
    [Header("Selected Drinks")]
    [SerializeField] private DebuffDrink debuff;
    [SerializeField] private BuffDrink buff;
    
    [SerializeField] private GameObject selectedDrinkBuff;
    [SerializeField] private GameObject selectedDrinkDebuff;
    
    [Header("UI Data")]
    [SerializeField] private GameObject drinkPanel;
    [SerializeField] private PlayerData playerData;
    
    private Transform drinksContainer;
    public static Action<DrinkSerializable> drinkSelected;
    public static Action<DrinkSerializable> updateEquippedItem;
    // Start is called before the first frame update
    void Start()
    {
        PopulateDrinks();        
    }

    private void OnEnable()
    {
        InventoryItem.OnDrinkAdded += HandleDrinkAdded;
    }

    private void OnDisable()
    {
        InventoryItem.OnDrinkAdded -= HandleDrinkAdded;
    }

    private void HandleDrinkAdded(DrinkSerializable drink)
    {
        switch (drink.type)
        {
            case DrinkType.Buff:
                
                buff = drink as BuffDrink;
                TextMeshProUGUI textBuff = selectedDrinkBuff.GetComponentInChildren<TextMeshProUGUI>();
                playerData.SelectedBuffDrink = drink as BuffDrink;
                textBuff.text = buff.name;
                break;
            
            case DrinkType.Debuff:
                
                debuff = drink as DebuffDrink;
                TextMeshProUGUI textDebuff = selectedDrinkDebuff.GetComponentInChildren<TextMeshProUGUI>();
                playerData.SelectedDebuffDrink = drink as DebuffDrink;
                textDebuff.text = debuff.name;
                break;
        }
    }
    
    private void PopulateDrinks()
    {
        foreach (var drink in playerData.unlockedDrinks)
        {
            GameObject newItem = Instantiate(drinkPanel, this.gameObject.transform);
            InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
            if (inventoryItem != null)
            {
                inventoryItem.SetDrink(drink);
            }
        }
    }
}
