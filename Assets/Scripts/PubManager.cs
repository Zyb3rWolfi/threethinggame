using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Pub manager responsbile for handling the player object going past the pub and assiging a drink 
public class PubManager : MonoBehaviour
{
    /* Variables:
     * - PlayerDataScriptable playerData: This is the player data
     * - static PubManager instance: This is the instance of the pub manager
     * - BoxCollider2D boxCollider: Used to manage the Trigger event
     * - MixerSerializable currentMixer: The current mixer that the player is on
     * - static Action<MixerSerializable> activateMixer: This is the action that is called when the player goes past the pub
     * Events:
     * - activateMixer: Calls an event to change the speed or add any other effects
     */
    
    [SerializeField] private PlayerDataScriptable playerData;
    public static PubManager instance;
    private BoxCollider2D boxCollider;
    private MixerSerializable currentMixer;
    public static Action<MixerSerializable> unlockMixer;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        currentMixer = playerData.Mixers[playerData.PubNumber];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerData.UnlockedDebuffDrinks[playerData.PubNumber] = currentMixer.alcohol;
        playerData.PubNumber++;
    }
}
