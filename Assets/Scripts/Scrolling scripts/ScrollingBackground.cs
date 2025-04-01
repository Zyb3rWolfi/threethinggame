using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    [SerializeField] private GameObject[] _groundPrefabs;
    [SerializeField] private GameObject[] _skyPrefabs;
    [SerializeField] private GameObject[] _cloudPrefabs;
    [SerializeField] private GameObject[] _initialPrefabs;
    public void OnEnable()
    {
        Scroller.createNew += createNew;
    }

    public void OnDisable()
    {
        Scroller.createNew -= createNew;
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject prefab in _initialPrefabs)
        {
            prefab.transform.position = new Vector3(0,0,0);
        }
    }

    private void createNew(string type, float xPos){
        if (type == "ground")
        {
            Instantiate(_groundPrefabs[Random.Range(0, _groundPrefabs.Length)], new Vector3(xPos, 0, 0), Quaternion.identity);
        }
        else if (type == "sky")
        {
            Instantiate(_skyPrefabs[Random.Range(0, _skyPrefabs.Length)], new Vector3(xPos, 0, 0), Quaternion.identity);
        }
        else if (type == "cloud")
        {
            Instantiate(_cloudPrefabs[Random.Range(0, _cloudPrefabs.Length)], new Vector3(xPos, 0, 0), Quaternion.identity);
        }
    }
}
