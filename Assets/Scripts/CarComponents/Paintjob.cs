using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintjob : CarComponentBase
{
    [SerializeField] private Material _colour;

    public Material GetColour()
    {
        return _colour;
    }

}
