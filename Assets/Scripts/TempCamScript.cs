using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TempCamScript : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, player.position.y + offset ,gameObject.transform.position.z);
    }
}
