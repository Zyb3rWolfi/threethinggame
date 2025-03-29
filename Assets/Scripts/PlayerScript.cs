using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] private float multiplier = 1.0f;
    [SerializeField] private float baseForce = 600f;
    [SerializeField] private float baseTriggerChance = 100f;
    [SerializeField] private float triggerChance;
    [SerializeField] private float windForce = 100f;
    [SerializeField] private float force; 

    private Vector3 startPos;
    private Rigidbody2D rb;
    private bool flying;

    public static Action<float> modifySpeed;

    [Header("Modifiers")]
    // Buffs applied by drinks
    [SerializeField] private float speed_modifier;
    [SerializeField] private float triggerChanceModifier;

    // Debuffs Applied by drinks 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = baseForce;
        triggerChance = baseTriggerChance;
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        print(startPos.x + " " + startPos.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (flying){ modifySpeed?.Invoke(((gameObject.transform.position.y - startPos.y)*0.5f));}
    }

    private void OnEnable()
    {
        MixedDrinkManager.mixerSelected += ManageMixer;
    }

    private void OnDisable()
    {
        MixedDrinkManager.mixerSelected -= ManageMixer;
    }

    private void ManageMixer(Modifiers modifiers)
    {
        multiplier = modifiers.speed;
    }

    public void Wind(InputAction.CallbackContext context){ 
      if (context.started == true){
        if (flying) return;
        if (UnityEngine.Random.Range(0, triggerChance) < 1){
          flying = true;
          rb.constraints = RigidbodyConstraints2D.FreezePositionX;
          rb.AddForce(Vector2.up * baseForce * (multiplier));
          return;
        }
        force += windForce;
        triggerChance = triggerChance / 2;
        print(force);
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3){ 
          print(startPos.x + " " + startPos.y);
          gameObject.transform.position  = startPos;
          rb.constraints = RigidbodyConstraints2D.FreezeAll;
          modifySpeed?.Invoke(0);
          force = baseForce;
          triggerChance = baseTriggerChance;
          flying = false;
        }
    }

}
