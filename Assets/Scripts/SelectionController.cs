using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Jobs;

public class SelectionController : MonoBehaviour
{
    [SerializeField] private int _carIndex, _colourIndex;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SelectionController.Start()");

        // set starting car to active
        ObjectPool.sharedInstance.GetCar(_carIndex).SetActive(true);

        // paint on starting colour
        UpdateCarColour();
    }

    // Update is called once per frame
    void Update()
    {
        // Change Model
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Q key pressed");

            ChangeModel(false);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("E key pressed");

            ChangeModel();
        }

        // Change Colour
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A key pressed");

            ChangeColour(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D key pressed");

            ChangeColour();
        }

        // List Colours
        if (Input.GetKeyDown(KeyCode.S))
        {
            LogColours();
        }

    }

    // --- MODELS --- //
    public void ChangeModel(bool next = true)
    {
        int prevIndex = _carIndex;

        // select next model
        if (next)
        {
            if (_carIndex < transform.childCount - 1)
            {
                _carIndex++;
                //Debug.Log("Moving to " + _carIndex);
            }
            // loop around if reaching the end
            else
            {
                //Debug.Log("Looping to 0");
                _carIndex = 0;
            }
        }
        // select previous model
        else
        {
            if (_carIndex > 0)
            {
                _carIndex--;
                //Debug.Log(_carIndex);
            }
            // loop around if reaching the end
            else
            {
                //Debug.Log("Looping to " + (transform.childCount - 1));
                _carIndex = transform.childCount - 1;
            }
        }

        // make sure it's the right colour
        UpdateCarColour();

        // activate current car
        GameObject carGO = ObjectPool.sharedInstance.GetCar(_carIndex);
        carGO.SetActive(true);

        // deactivate previous car
        carGO = ObjectPool.sharedInstance.GetCar(prevIndex);
        carGO.SetActive(false);
    }


    // --- COLOURS --- //
    private void LogColours()
    {
        int numOfColours = ObjectPool.sharedInstance.GetColourCount();

        Debug.Log("numOfMaterials = " + numOfColours);

        for (int i = 0; i < numOfColours; i++)
        {
            Debug.Log(ObjectPool.sharedInstance.GetColour(i).name + " - " + i);
        }
    }
    public void ChangeColour(bool next = true)
    {
        int numOfColours= ObjectPool.sharedInstance.GetColourCount();
        int prevColour;

        // select next colour
        if (next)
        {
            // if there's space increment
            if (_colourIndex != numOfColours - 1)
            {
                prevColour = _colourIndex;
                _colourIndex++;

                //Debug.Log("next: " + ObjectPool.sharedInstance.GetColour(prevColour) + "(" + (prevColour) + ") -> " + ObjectPool.sharedInstance.GetColour(_colourIndex) + "(" + _colourIndex + ")");
            }
            // otherwise loop around
            else
            {
                //Debug.Log("next: looping");

                prevColour = _colourIndex;
                _colourIndex = 0;

                //Debug.Log("next: " + ObjectPool.sharedInstance.GetColour(prevColour) + "(" + (prevColour) + ") -> " + ObjectPool.sharedInstance.GetColour(_colourIndex) + "(" + _colourIndex + ")");
            }
        }
        // select previous colour
        else
        {
            // if there's space decrement
            if (_colourIndex != 0)
            {
                prevColour = _colourIndex;
                _colourIndex--;

                //Debug.Log("next: " + ObjectPool.sharedInstance.GetColour(prevColour) + "(" + (prevColour) + ") -> " + ObjectPool.sharedInstance.GetColour(_colourIndex) + "(" + _colourIndex + ")");
            }
            // otherwise loop around
            else
            {
                prevColour = _colourIndex;
                _colourIndex = numOfColours - 1;

                //Debug.Log("next: " + ObjectPool.sharedInstance.GetColour(prevColour) + "(" + (prevColour) + ") -> " + ObjectPool.sharedInstance.GetColour(_colourIndex) + "(" + _colourIndex + ")");
            }
        }

        UpdateCarColour();
    }

    private void UpdateCarColour()
    {
        // get the current car
        Transform carTF = ObjectPool.sharedInstance.GetCar(_carIndex).transform;
        // get that car's body
        Transform bodyTF = carTF.GetChild(0).GetChild(0);
        // get that body's renderer
        Renderer renderer = bodyTF.GetComponent<Renderer>();

        //Debug.Log(bodyTF.name + " -> material component -> " + renderer.material);
        //Debug.Log("materialList[0] -> " + ObjectPool.sharedInstance.GetColour(0));

        // set the material to the desired colour
        renderer.material = ObjectPool.sharedInstance.GetColour(_colourIndex);
    }
}