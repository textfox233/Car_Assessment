using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    enum colour
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

    private int _model;
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

    }


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

    private void ChangeMaterial(bool forward = true)
    {
        //colour.GetNames().Length;

        if(forward)
        {
            Debug.Log("forward");
        }
        else
        {
            Debug.Log("backward");
        }
    }
}