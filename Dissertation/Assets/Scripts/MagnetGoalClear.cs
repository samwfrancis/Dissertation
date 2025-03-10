using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetGoalClear : MonoBehaviour
{

    public GameObject platform;
    public GameObject shipPart;
    // Start is called before the first frame update
    void Start()
    {
        platform.SetActive(false);
        shipPart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Magnetic")){
        platform.SetActive(true);
        shipPart.SetActive(true);
      }  
    }
}
