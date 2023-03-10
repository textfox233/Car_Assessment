using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
