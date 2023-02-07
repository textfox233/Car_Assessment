using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetails : MonoBehaviour
{
    [SerializeField] private int _modelPrice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //colour.GetNames().Length;
    }

    int GetModelPrice()
    {
        return _modelPrice;
    }
}
