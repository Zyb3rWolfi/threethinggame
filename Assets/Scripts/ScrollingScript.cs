using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    [SerializeField] private float speed;
    public float swapDistance = 10f; // Distance threshold for swapping materials
    public bool isMoving = true;

    [SerializeField]
    private Renderer bgRenderer;

    [SerializeField]
    private Material material1;

    [SerializeField]
    private Material material2;

    private bool useMaterial1 = true;
    private float scrolledDistance = 0f;

    [SerializeField] private float speedMult;
    [SerializeField] private float catapultInc;

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            float offset = speed * Time.deltaTime;
            bgRenderer.material.mainTextureOffset += new Vector2(offset, 0);
            scrolledDistance += offset;

            if (scrolledDistance >= swapDistance)
            {
                SwapMaterials();
                scrolledDistance = 0f; // Reset the scrolled distance after swapping
            }
        }
    }

    public void SwapMaterials()
    {
        if (useMaterial1)
        {
            bgRenderer.material = material2;
        }
        else
        {
            bgRenderer.material = material1;
        }
        useMaterial1 = !useMaterial1;
    }

    public void OnEnable()
    {
        PlayerScript.modifySpeed += ChangeSpeed;
        MixedDrinkManager.mixerSelected += ManageModifiers;
    }

    public void OnDisable()
    {
        PlayerScript.modifySpeed -= ChangeSpeed;
        MixedDrinkManager.mixerSelected -= ManageModifiers;
    }

    private void ChangeSpeed(float newSpeed) {
        speed = newSpeed;
    }

    private void ManageModifiers(Modifiers modifiers)
    {
        speedMult = modifiers.speed;
        catapultInc = modifiers.catapultForce;
    }
}

