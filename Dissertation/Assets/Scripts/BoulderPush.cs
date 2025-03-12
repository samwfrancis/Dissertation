using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderPush : MonoBehaviour
{

    public float secondsElasped;
    public float boulderTimeStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boulderTimeStart = secondsElasped;
        }
    }
}
