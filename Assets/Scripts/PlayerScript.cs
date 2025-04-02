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
    // Serialized Fields
    [Header("Base Stats")]
    [SerializeField] private float multiplier = 1.0f;
    [SerializeField] private float baseForce = 600f;
    [SerializeField] private float baseTriggerChance = 100f;
    [SerializeField] private float triggerChance;
    [SerializeField] private float windForce = 100f;
    [SerializeField] private float force; 
    [SerializeField] private float rotationSpeed = 100f;
    
    [Header("Modifiers")]
    [SerializeField] private bool increasedChance = false;
    [SerializeField] public float distanceTraveled;
    [SerializeField] private int hasWound;
    
    [Header("Game Objects")]
    [SerializeField] private ProgressBar distanceBar;
    [SerializeField] private SmoothCamera playerCamera;
    [SerializeField] private float goalDistance = 100f;
    private SpriteRenderer spriteRenderer; 
    
    [Header("Runtime Variables")]
    [SerializeField] private float currentSpeed;  
    private Vector3 startPos;
    private Rigidbody2D rb;
    private bool flying;
    
    // Events
    // - ModifySpeed Changes the speed of the player
    // - StartAnimation (1) Starts the winding animation
    // - StartAnimation (2) Starts the flying animation
    public static Action<float> modifySpeed;
    public static Action<int> startAnimation;
    public static Action increaseWindStreak;
    public static Action HitGround;
    public static Action HideStreak;
    private bool animationStarted;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animationStarted = false;
        spriteRenderer.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        force = baseForce;
        increasedChance = false; 
        triggerChance = baseTriggerChance;
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        print(startPos.x + " " + startPos.y);
    }

    private void FixedUpdate() {
      
      if (flying){
        currentSpeed = ((gameObject.transform.position.y - startPos.y)*0.5f);
        modifySpeed?.Invoke(currentSpeed);
        distanceTraveled += currentSpeed * Time.deltaTime;
        playerCamera.ChangeCameraZoom(currentSpeed);
        distanceBar.UpdateProgressBar(distanceTraveled / goalDistance);
        rb.AddTorque(rotationSpeed * Time.deltaTime);
      }
    }

    private void OnEnable()
    {
        MixedDrinkManager.mixerSelected += ManageMixer;
        CarManager.carBoost += DuckFly;
        Catapultanimation.MakeCatapultFly += DuckFly;
        increasedChance = true;
    }

    private void OnDisable()
    {
        MixedDrinkManager.mixerSelected -= ManageMixer;
        CarManager.carBoost -= DuckFly;
        Catapultanimation.MakeCatapultFly -= DuckFly;
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
            increaseWindStreak?.Invoke();
            
            if (!animationStarted)
            {
                startAnimation?.Invoke(1);
                animationStarted = true;
            }
            
            if (increasedChance && hasWound > 1)
            {
                triggerChance += (triggerChance / 2);
            }
            
            if (UnityEngine.Random.Range(0, triggerChance) < 1){
                startAnimation?.Invoke(2);
                HideStreak?.Invoke();
                return;
            }

            triggerChance /= 2;
            force += windForce;
            print(force);
        }
    }

    private void DuckFly()
    {
        if (flying) return;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb.AddForce(Vector2.up * baseForce * (multiplier));
        float randomRotation = UnityEngine.Random.Range(-180f, 180f);
        rb.rotation = randomRotation;
        spriteRenderer.enabled = true;
        flying = true;
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
          if (flying)
          {
            HitGround?.Invoke();  
          }
          flying = false;
        }
    }

}
