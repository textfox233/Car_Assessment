using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintDetails : MonoBehaviour
{
    // paintjob in question
    public Paintjob paintjob;

    // Getters
    public int GetCost() { return paintjob.cost; }
    public Material GetColour() { return paintjob.colour; }
}
