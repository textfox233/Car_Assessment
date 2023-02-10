using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;

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
    // update the cost element
    {
        // get the cost element's text box
        Text value = transform.Find("Cost Window").GetComponentInChildren<Text>();

        // Apply the new cost
        value.text = "£" + newCost.ToString();
    }

    public void UpdateStats(float acceleration, float topSpeed, float turnRate, int maxHP)
    // update the stats element
    {
        // get the stats container
        Transform statsTR = transform.Find("Stats Window").Find("Stats");

        // find and edit all text elements
        // acceleration
        Text txt = statsTR.Find("Acceleration").GetComponentInChildren<Text>();
        txt.text = acceleration.ToString();

        // top speed 
        txt = statsTR.Find("Top Speed").GetComponentInChildren<Text>();
        txt.text = topSpeed.ToString();

        // turn rate
        txt = statsTR.Find("Turn Rate").GetComponentInChildren<Text>();
        txt.text = turnRate.ToString();

        // max HP
        txt = statsTR.Find("Max HP").GetComponentInChildren<Text>();
        txt.text = maxHP.ToString();
    }
}
