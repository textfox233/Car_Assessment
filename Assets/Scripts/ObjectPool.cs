using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject CarControllerGO;

    public static ObjectPool sharedInstance;
    public List<GameObject> pooledObjectList;
    //public GameObject objectToPoolGO;

    private int _amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        pooledObjectList = new List<GameObject>();
        GameObject tmpGO;

        // --- Generate new objects --- //
        //for (int i = 0; i < _amountToPool; i++)
        //{
        //    tmpGO = Instantiate(objectToPoolGO);    // make a game object
        //    tmpGO.SetActive(false);                 // set it to inactive
        //    pooledObjectList.Add(tmpGO);            // add it to the list
        //}

        // --- Add existing objects --- //

        // --- get car prefabs via tags (ONLY returns active objects)
        //GameObject[] arrGO = GameObject.FindGameObjectsWithTag("Car Model");
        //for (int i = 0; i < arrGO.Length; i++)
        //{
        //    Debug.Log(arrGO[i].name);
        //}

        // get car prefabs via parent
        _amountToPool = CarControllerGO.transform.childCount;

        for (int i = 0; i < _amountToPool; i++)
        {
            tmpGO = CarControllerGO.transform.GetChild(i).gameObject;    // get a game object
            //tmpGO.SetActive(false);                 // set it to inactive
            pooledObjectList.Add(tmpGO);            // add it to the list
        }
    }

    public GameObject GetPooledObject(bool active = false)
    // return an object from the pool (boolean specifies active or inactive objects)
    {
        // first inactive object in the pool
        if (!active)
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                if (!pooledObjectList[i].activeInHierarchy)
                {
                    return pooledObjectList[i];
                }
            }

            // null if there's no inactive objects in the pool
            Debug.Log("no inactive objects in the pool");
            return null;
        }
        // last active object in the pool
        else
        {
            for (int i = _amountToPool - 1; i >= 0; i--)
            {
                if (pooledObjectList[i].activeInHierarchy)
                {
                    return pooledObjectList[i];
                }
            }
           
            // null if there's no active objects in the pool
            Debug.Log("no active objects in the pool");
            return null;
        }
    }

    public GameObject GetPooledObject(int index)
    {
        if (index >= _amountToPool || index < 0)
        {
            Debug.Log(index + " is out of bounds");
            return null;

        }

        return pooledObjectList[index];
    }

}