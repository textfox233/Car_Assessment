using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class SelectionController : MonoBehaviour
{
    enum EMaterial
    // indicates chosen material
    {
        Black,      // 1
        Blue,       // 2
        Dark_Blue,  // 3
        Brown,      // 4
        Gray,       // 5
        Green,      // 6
        Orange,     // 7
        Pink,       // 8
        Red,        // 9
        Turquoise,  // 10
        Violet,     // 11
        White,      // 12
        Yellow      // 13
    }

    //[SerializeField] private GameObject gameControllerGO;
    //[SerializeField] private GameObject carGO;

    private EMaterial _colour;
    private int _carIndex;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start()");
    }

    // Update is called once per frame
    void Update()
    {
        // get A car object and set it to active
        //GameObject car = ObjectPool.sharedInstance.GetPooledObject();
        //if (car != null)
        //{
        //    car.SetActive(true);
        //}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q key press");

            ChangeModel(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key press");

            ChangeModel();            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A key press");


            // get SPECIFIC car object and set it to active
            //GameObject car = ObjectPool.sharedInstance.GetPooledObject(2);
            //if (car != null)
            //{
            //    car.SetActive(true);
            //}
            ChangeMaterial(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D key press");


            // get SPECIFIC car object and set it to inactive
            //GameObject car = ObjectPool.sharedInstance.GetPooledObject(2);
            //if (car != null)
            //{
            //    car.SetActive(false);
            //}
            ChangeMaterial();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DisplayMaterials();
        }

    }

    // --- MODELS --- //
    private void ChangeModel(bool forward = true)
    {
        int prevIndex = _carIndex;

        // move up the car index
        if (forward)
        {
            if (_carIndex < transform.childCount - 1)
            {
                _carIndex++;
                Debug.Log("Moving to " + _carIndex);
            }
            // loop around if reaching the end
            else
            {
                Debug.Log("Looping to 0");
                _carIndex = 0;
            }
        }
        // move down the car index
        else
        {
            if (_carIndex > 0)
            {
                _carIndex--;
                Debug.Log(_carIndex);
            }
            // loop around if reaching the end
            else
            {
                Debug.Log("Looping to " + (transform.childCount - 1));
                _carIndex = transform.childCount - 1;
            }
        }

        // activate current car
        GameObject car = ObjectPool.sharedInstance.GetPooledObject(_carIndex);
        car.SetActive(true);

        // deactivate previous car
        car = ObjectPool.sharedInstance.GetPooledObject(prevIndex);
        car.SetActive(false);
    }


    // --- MATERIALS --- //
    private void DisplayMaterials()
    {
        string[] materials = EMaterial.GetNames(typeof(EMaterial));

        Debug.Log("numOfMaterials = " + EMaterial.GetNames(typeof(EMaterial)).Length);

        for(int i = 0; i < materials.Length; i++)
        {
            Debug.Log(materials[i] + " - " + i);
        }
    }
    private void ChangeMaterial(bool forward = true)
    {
        int matLength = EMaterial.GetNames(typeof(EMaterial)).Length;
        EMaterial oldColour = _colour;

        if (forward)
        {
            // if there's space increment
            if ((int)_colour != matLength - 1)
            {
                _colour++;
                Debug.Log("forward: " + oldColour + "(" + ((int)oldColour) + ") -> " + _colour + "(" + ((int)_colour) + ")");
            }
            // otherwise loop around
            else
            {
                //Debug.Log("forward: out of range");
                Debug.Log("forward: looping");

                _colour = Enum.GetValues(typeof(EMaterial)).Cast<EMaterial>().Min();
                Debug.Log("backward: " + oldColour + "(" + ((int)oldColour) + ") -> " + _colour + "(" + ((int)_colour) + ")");
            }
        }
        else
        {
            // if there's space decrement
            if ((int)_colour != 0)
            {
                _colour--;
                Debug.Log("backward: " + oldColour + "(" + ((int)oldColour) + ") -> " + _colour + "(" + ((int)_colour) + ")");
            }
            // otherwise loop around
            else
            {
                Debug.Log("backward: looping");
             
                _colour = Enum.GetValues(typeof(EMaterial)).Cast<EMaterial>().Max();
                Debug.Log("backward: " + oldColour + "(" + ((int)oldColour) + ") -> " + _colour + "(" + ((int)_colour) + ")");

                //Debug.Log("backward: out of range");
            }
        }
    }
}