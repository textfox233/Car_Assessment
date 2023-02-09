using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    [SerializeField] private int _cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //colour.GetNames().Length;
    }

    public int GetCost()
    {
        return _cost;
    }
}
