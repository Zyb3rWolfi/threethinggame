using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static Action carBoost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        carBoost?.Invoke();
    }
}
