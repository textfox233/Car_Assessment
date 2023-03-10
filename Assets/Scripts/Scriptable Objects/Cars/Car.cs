using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class Car : ScriptableObject
{
    public new string name;
    
    // cost
    public int cost;

    // stats
    public float acceleration;
    public float topSpeed;
    public float turnRate;
    public int maxHP;

    public void Print ()
    {
        Debug.Log("The " + name + " costs " + cost.ToString());
    }
}