using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> carList;
    [SerializeField] private List<Paintjob> colourList;

    public static ObjectPool sharedInstance;

    private int _numCars, _numColours;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        Debug.Log("ObjectPool.Start()");
       
        // --- Cars --- //
        carList = new List<GameObject>();
        GameObject tmpGO;

        GameObject carsGO = gameObject.GetComponent<GameController>().getCars();

        // get the car prefabs via parent
        _numCars = carsGO.transform.childCount;
        for (int i = 0; i < _numCars; i++)
        {
            tmpGO = carsGO.transform.GetChild(i).gameObject;    // get a game object
            tmpGO.SetActive(false);                             // set it to inactive
            carList.Add(tmpGO);                                 // add it to the list
        }

        // --- Colours --- //
        _numColours = colourList.Count;
    }

    public GameObject GetCar(bool active = false)
    // return an object from the pool (boolean specifies active or inactive objects)
    {
        // first inactive object in the pool
        if (!active)
        {
            for (int i = 0; i < _numCars; i++)
            {
                if (!carList[i].activeInHierarchy)
                {
                    return carList[i];
                }
            }

            // null if there's no inactive objects in the pool
            Debug.Log("ObjectPool ERROR: no inactive objects in the pool");
            return null;
        }
        // last active object in the pool
        else
        {
            for (int i = _numCars - 1; i >= 0; i--)
            {
                if (carList[i].activeInHierarchy)
                {
                    return carList[i];
                }
            }
           
            // null if there's no active objects in the pool
            Debug.Log("ObjectPool ERROR: no active objects in the pool");
            return null;
        }
    }

    public GameObject GetCar(int index)
    // return an object from the pool by index
    {
        if (index >= _numCars || index < 0)
        {
            Debug.Log("ObjectPool.GetCar() ERROR: " + index + " is out of bounds");
            return null;
        }

        return carList[index];
    }

    public Paintjob GetColour(int index)
    {
        if (index >= _numColours || index < 0)
        {
            Debug.Log("ObjectPool.GetColour() ERROR: " + index + " is out of bounds");
            return null;
        }

        return colourList[index];
    }

    public int GetColourCount()
    {
        return _numColours;
    }
}