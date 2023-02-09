using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateCost(int newCost)
    {
        // get the cost element's text box
        Transform value = transform.Find("Cost").Find("Label").GetChild(0);

        // Apply the new cost
        value.GetComponent<Text>().text = "£" + newCost.ToString();
    }
}
