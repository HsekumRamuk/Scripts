using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    // creating My variables
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 10f;
    [SerializeField] AudioClip rocketEngineThrust;
    [SerializeField] ParticleSystem mainEngineThrustParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticels;

    AudioSource myThrustAudio;
    Rigidbody MyRigidBody;
    

    // Start is called before the first frame update
    void Start()
    {
       MyRigidBody = GetComponent<Rigidbody>();
       myThrustAudio = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
            // calling the method here
        ProcessThrust();
        ProcessRotation();
        
        
    }

        // This is my method
        void ProcessThrust()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                MyRigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
                if (!myThrustAudio.isPlaying)
                {
                    myThrustAudio.PlayOneShot(rocketEngineThrust);
                }

                if (!mainEngineThrustParticles.isPlaying)
                {
                    mainEngineThrustParticles.Play();
                }
            }

            else
            {
                myThrustAudio.Stop();
                mainEngineThrustParticles.Stop();
            }

        }
            // // Created method here
        void ProcessRotation()
        {
             if (Input.GetKey(KeyCode.A))
             {
                //Calling method here
                ApplyRotation(rotationThrust);

                if (!rightThrustParticels.isPlaying)
                 {
                     rightThrustParticels.Play();
                 }
               
             }
             
             
             else if (Input.GetKey(KeyCode.D))
             {
                //Calling method here
                 ApplyRotation(-rotationThrust);

                 if (!leftThrustParticles.isPlaying)
                 {
                    leftThrustParticles.Play();
                 }
             }

             else
             {
                rightThrustParticels.Stop();
                leftThrustParticles.Stop();
             }
        }       
            // Created method here
          void ApplyRotation(float myRotation)
         {
            MyRigidBody.freezeRotation = true; //Freeze rotation so we can manually rotate  
            transform.Rotate(Vector3.forward * myRotation * Time.deltaTime);                                        
            MyRigidBody.freezeRotation = false; // unfreezing rotation so physics system can take over
         }




}

