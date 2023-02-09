using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _carControllerGO;
    [SerializeField] private GameObject _UIControllerGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getCars()
    // get the car controller
    {
        return _carControllerGO;
    }

    public GameObject getUI()
    // get the UI controller
    {
        return _UIControllerGO;
    }
}
