using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using Unity.IO.LowLevel.Unsafe;

public abstract class Scroller : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject start;
    private float startPos;

    public static Action<string, float> createNew;
    private bool createdNew = false;

    public void OnEnable()
    {
        PlayerScript.modifySpeed += ChangeSpeed;
    }

    public void OnDisable()
    {
        PlayerScript.modifySpeed -= ChangeSpeed;
    }

    void Start()
    {
        startPos = start.transform.position.x;
    }

    public abstract string getType();

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.left  * speed * Time.deltaTime);  
        if (end.transform.position.x <= startPos)
        {
            if (!createdNew){

                createNew?.Invoke(getType(), end.transform.position.x + (gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2));
                print("create new");
                createdNew = true;
            }
            if (end.transform.position.x < startPos - gameObject.GetComponent<SpriteRenderer>().bounds.size.x)
            {
                Destroy(gameObject);
            }
        }

    }

    public virtual void ChangeSpeed(float newSpeed) {
    speed = newSpeed;
    }
}
