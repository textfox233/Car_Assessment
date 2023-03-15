using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    // car in question
    [SerializeField] private Car car;

    // getters
    public int GetCost()            { return car.GetCost(); }
    public float GetAcceleration()  { return car.GetAcceleration(); }
    public float GetTopSpeed()      { return car.GetTopSpeed(); }
    public float GetTurnRate()      { return car.GetTurnRate(); }
    public int GetMaxHP()           { return car.GetMaxHP(); }
}
