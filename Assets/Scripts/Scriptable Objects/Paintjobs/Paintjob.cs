using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Paintjob", menuName = "Paintjob")]
public class Paintjob : ScriptableObject
{
    public new string name;

    // cost
    public int cost;
    
    // material / colour
    public Material colour;
}
