using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGoodScript : MonoBehaviour
{
    [SerializeField] public float _scrollspeed = 2f;

    public float _imageWidth;
    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        _imageWidth = spriteRenderer.size.x;

        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size *= new Vector2(3, 1);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * _scrollspeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x) >= _imageWidth)
        {
            transform.position = Vector3.zero;
        }
    }
}
