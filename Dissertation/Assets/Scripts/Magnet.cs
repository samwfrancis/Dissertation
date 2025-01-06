using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float forcefactor = 200f;

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
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Magnetic")){
            rgBalls.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
