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

    public float distanceTraveled = 0;   
    private float currentSpeed;  
    [SerializeField] private ProgressBar distanceBar;
    [SerializeField] private float goalDistance = 100f;
    
    // Buffs applied by drinks
    [SerializeField] private float catapultIncrease;
    [SerializeField] private float speed;
    [SerializeField] private float triggerChanceModifier;

    // Debuffs Applied by drinks 
    [SerializeField] private float catapultDecrease;
    [SerializeField] private



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
    }

    private void OnDisable()
    {

    }

    private void ManageMixer(Modifiers modifiers)
    {
        speed = speed * modifiers.speed;
        triggerChance = modifiers.triggerChance;
        catapultIncrease = modifiers.catapultIncrease;
    }

    public void Wind(InputAction.CallbackContext context){ 
      if (context.started == true){
        if (flying) return;
        if (UnityEngine.Random.Range(0, triggerChance) < 1){
          flying = true;
          rb.constraints = RigidbodyConstraints2D.FreezePositionX;
          rb.AddForce(Vector2.up * baseForce * (multiplier * catapultIncrease));
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
