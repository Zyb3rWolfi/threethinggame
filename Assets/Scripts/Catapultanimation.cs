using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapultanimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public static Action MakeCatapultFly;

    private void OnEnable()
    {
        PlayerScript.startAnimation += StartAnimationNow;
    }
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void StartAnimationNow(int animationIndex)
    {
        switch (animationIndex)
        {
            case 1:
                animator.SetTrigger("Start");
                break;
            case 2:
                animator.SetTrigger("Fly");
                break;
        }
    }

    public void AnimationFinished()
    {
        MakeCatapultFly?.Invoke();
        gameObject.SetActive(false);
    }
}
