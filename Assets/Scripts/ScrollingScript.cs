using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public float speed;
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

    private void OnEnable()
    {
        MixedDrinkManager.mixerSelected += ManageMix;
    }

    private void ManageMix(Modifiers modifiers)
    {
        speed = speed * modifiers.speed;
    }
}

