using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGoalCleared : MonoBehaviour
{

    public GameObject shipPart;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        shipPart.SetActive(false);
        platform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Ball")){
        shipPart.SetActive(true);
        platform.SetActive(true);
      }  
    }
}
