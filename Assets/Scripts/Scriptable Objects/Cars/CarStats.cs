using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    // car in question
    [SerializeField] private Car car;

    // getters
    public int GetCost()            { return car.cost; }
    public float GetAcceleration()  { return car.acceleration; }
    public float GetTopSpeed()      { return car.topSpeed; }
    public float GetTurnRate()      { return car.turnRate; }
    public int GetMaxHP()           { return car.maxHP; }
}
