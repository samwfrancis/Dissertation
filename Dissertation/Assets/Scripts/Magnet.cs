using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Magnet : MonoBehaviour
{
    public float forcefactor = 200f;
    public bool isRumble;

    List<Rigidbody> rgBalls = new List<Rigidbody>(); 

    Transform magnetPoint;
    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        foreach(Rigidbody rgball in rgBalls)
        {
            rgball.AddForce((magnetPoint.position - rgball.position) * forcefactor * Time.fixedDeltaTime);
            
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Magnetic"))
            rgBalls.Add(other.GetComponent<Rigidbody>());
            if (isRumble)
            {
                Gamepad.current.SetMotorSpeeds(0.123f, 0.234f);
                
            }
            else 
            {
                Gamepad.current.SetMotorSpeeds(0,0);
            }
            
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Magnetic")){
            rgBalls.Remove(other.GetComponent<Rigidbody>());
            Gamepad.current.SetMotorSpeeds(0,0);
        }
    }
}
