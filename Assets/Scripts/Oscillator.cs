using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    // 'direction', 'border' and 'speed' are used to control the distance limit and moving speed and direction.
    [SerializeField]
    RectTransform.Axis direction = RectTransform.Axis.Horizontal;
    [SerializeField]
    float border = 5.0f;
    [SerializeField]
    float speed = 2.0f;

    // The initial position of the object:
    Vector3 startPoint;
    void Start()
    {
        startPoint = transform.position;
    }

    void Update()
    {
        // Calculation of the distance for each frame:
        // Time.time is increasing every moment and making Sin() grow from 0 to 1 and then down to -1 and so on...
        // We get that: -border < distance < border.
        float distance = border * Mathf.Sin(Time.time * speed);

        // Move the object on the X or Y axis to startPoint+distance and keep the other axis unchanged.
        // The object's weight center is startPoint.
        if (direction == RectTransform.Axis.Horizontal)
            transform.position = new Vector3(startPoint.x + distance, startPoint.y, startPoint.z);
        else
            transform.position = new Vector3(startPoint.x, startPoint.y + distance, startPoint.z);

    }
}