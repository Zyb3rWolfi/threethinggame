using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.Rendering;
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
    [SerializeField] private bool increasedChance = false;
    [SerializeField] private float windForce = 100f;
    [SerializeField] private float force; 

    private Vector3 startPos;
    private Rigidbody2D rb;
    private bool flying;

    public static Action<float> modifySpeed;

    [Header("Modifiers")]

    public float distanceTraveled;   
    private float currentSpeed;  
    [SerializeField] private ProgressBar distanceBar;
    [SerializeField] private float goalDistance = 100f;

    [SerializeField] private int hasWound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        force = baseForce;
        triggerChance = baseTriggerChance;
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        print(startPos.x + " " + startPos.y);
    }

    private void FixedUpdate() {
      
      if (flying){
        currentSpeed = ((gameObject.transform.position.y - startPos.y)*0.5f);
        modifySpeed?.Invoke(currentSpeed);
        distanceTraveled += currentSpeed * Time.deltaTime;
        distanceBar.UpdateProgressBar(distanceTraveled / goalDistance);
      }
    }

    private void OnEnable()
    {
        MixedDrinkManager.mixerSelected += ManageMixer;
        increasedChance = true;
    }

    private void OnDisable()
    {
        MixedDrinkManager.mixerSelected -= ManageMixer;
    }

    private void ManageMixer(Modifiers modifiers)
    {
        multiplier = modifiers.speed;
        baseForce += modifiers.catapultForce;
        increasedChance = modifiers.triggerIncrease;
    }

    public void Wind(InputAction.CallbackContext context)
    {
        if (context.started)
        { if (flying) return;
            hasWound += 1;
            
            if (increasedChance && hasWound > 1)
            {
                triggerChance += (triggerChance / 2);
            }
            
            float i = UnityEngine.Random.Range(0, triggerChance);
            print("Chance: " + i);
            if (i < 1){
                flying = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.AddForce(Vector2.up * baseForce * (multiplier));
                return;
            }

            triggerChance /= 2;
            force += windForce;
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
