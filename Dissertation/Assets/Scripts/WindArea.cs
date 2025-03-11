using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector3 direction;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gamepad.current.SetMotorSpeeds(0.123f,0.234f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Gamepad.current.SetMotorSpeeds(0,0);
        }
    }
    
}
