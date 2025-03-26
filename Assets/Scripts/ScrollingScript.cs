using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    public float speed;
    public bool isMoving = true;
    public bool scrollUp = false; // New variable to control the direction of scrolling
    public Material secondMaterial; // New variable for the second material
    public float blendSpeed = 0.5f; // Speed of blending between materials

    private float offset;
    private Material material;
    private float blendFactor = 0.0f;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.SetTexture("_SecondTex", secondMaterial.GetTexture("_MainTex"));
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (scrollUp)
            {
                offset += (speed * Time.deltaTime);
                // this solution is not perfect, but it works for now
                // sets the texture of material with second material texture
                // but attempting to change back is kind of impossible
                material.SetTexture("_MainTex", secondMaterial.GetTexture("_MainTex"));
                material.SetTextureOffset("_MainTex", new Vector2(0, offset));
                blendFactor = Mathf.Clamp01(blendFactor + blendSpeed * Time.deltaTime);
            }
            else
            {
                offset += (speed * Time.deltaTime);
                material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
                blendFactor = Mathf.Clamp01(blendFactor - blendSpeed * Time.deltaTime);
            }

            material.SetFloat("_Blend", blendFactor);
        }
    }
}

