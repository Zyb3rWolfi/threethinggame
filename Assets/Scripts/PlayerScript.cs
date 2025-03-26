using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float multiplier = 1.0f;
    [SerializeField] private float baseForce = 600f;
    [SerializeField] private float triggerChance = 100f;
    [SerializeField] private float windForce = 100f;
    private Rigidbody2D rb;
    private bool flying;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        MixedDrinkManager.cokeAction += ManageMixer;
    }

    private void OnDisable()
    {
        MixedDrinkManager.cokeAction -= ManageMixer;

    }

    private void ManageMixer(MixerSerializable mixer)
    {
    }

    public void Wind(InputAction.CallbackContext context){ 
      if (context.started == true){
        if (flying) return;
        if (UnityEngine.Random.Range(0, triggerChance) < 1){
          flying = true;
          rb.constraints = RigidbodyConstraints2D.FreezePositionX;
          rb.AddForce(Vector2.up * baseForce * multiplier);
          return;
        }
        baseForce += windForce;
        triggerChance = triggerChance / 2;
        print(baseForce);
      }

    }
}
