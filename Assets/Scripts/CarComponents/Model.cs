using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : CarComponentBase
{
    // - The data values in here are all stuff I imagine would be useful in a racing game.
    // They don't really do anything other than seperate model from paintjob at the moment.

    [SerializeField] float _acceleration;
    [SerializeField] float _topSpeed;
    [SerializeField] float _turnRate;
    [SerializeField] int _maxHP;

    // --- GETTERS --- //
    public float GetAcceleration() { return _acceleration; }
    public float GetTopSpeed()     { return _topSpeed; }
    public float GetTurnRate()     { return _turnRate; }
    public int GetMaxHP()          { return _maxHP;}
}