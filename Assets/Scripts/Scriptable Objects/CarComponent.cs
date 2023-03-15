using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarComponent : ScriptableObject
{
    [SerializeField] new string name;

    [SerializeField] int _cost;
    public int GetCost()
    {
        return _cost;
    }
}
