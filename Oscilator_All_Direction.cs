using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscilator_All_Direction : MonoBehaviour
{
    // my created Variables here
    Vector3 startPosition;
    [SerializeField] Vector3 direction;
    [SerializeField] float speed = 1f;
    [Range(0,1)] float movementFactor; 


    // Start is called before the first frame update
    void Start()
    {

        // grab the initial position of the object
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (speed <= Mathf.Epsilon)     // protecting against Nan error
        {return;}
        float cycles = Time.time / speed;       // defining speed of the object
        float sinWave = MathF.Sin(cycles);      // generating the value from -1 and 0 using Sin function
        float movementFactor = (sinWave + 1) / 2;   // limit the value from 0 to 1
        Vector3 offset = direction * movementFactor;
        transform.position = startPosition + offset;

    }
}
