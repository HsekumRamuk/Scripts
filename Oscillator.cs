using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Oscillator : MonoBehaviour
{

    //creating variables here
    [SerializeField] float amplitude = 1f;
    [SerializeField] float frequency = 1f;
    float startPosition;
   

    // Start is called before the first frame update
    void Start()
    {
        
        // It stores the initial position of the object in X axis
         startPosition = transform.position.x;

    } 

    // Update is called once per frame
    void Update()
    {
        float sineWaves = Mathf.Sin(Time.time * frequency) * amplitude;     //it gives the value between -1 and 1
        float myWaves = (sineWaves + amplitude) / 2;        //it gives the value between 0 and 1 but depending on the value of amplitude
        float xPosition = myWaves + startPosition; 
        float yPosition = transform.position.y;     // It stores the initial position of the object in Y axis 
        float zPosition = transform.position.z;     // It stores the initial position of the object in Z axis
        transform.position = new Vector3(xPosition, yPosition, zPosition);
        
    }
}
