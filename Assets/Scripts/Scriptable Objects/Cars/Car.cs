using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class Car : CarComponent
{
    // stats
    [SerializeField] float acceleration;
    [SerializeField] float topSpeed;
    [SerializeField] float turnRate;
    [SerializeField] int maxHP;


    public float GetAcceleration() { return acceleration; }
    public float GetTopSpeed()     { return topSpeed; }
    public float GetTurnRate()     { return turnRate; }
    public int GetMaxHP()          { return maxHP; }
    public void Print ()
    {
        Debug.Log("The " + name + " costs " + GetCost().ToString());
    }
}