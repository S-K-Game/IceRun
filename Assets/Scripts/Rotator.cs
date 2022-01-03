using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Speed can be changed from the GUI.
    [SerializeField]
    float speed = 0.5f;
    float xRotation = 0;
    float yRotation = 0;
    Vector3 position;
    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        // Rotate the object in the Z axis.
        // You can rotate the on other axis by switching between the cordinates order.
        transform.Rotate(xRotation, yRotation, speed);
    }
}