using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paintjob", menuName = "Paintjob")]
public class Paintjob : CarComponent
{
    // material / colour
    [SerializeField] Material colour;

    public Material GetColour() { return colour; }
}
