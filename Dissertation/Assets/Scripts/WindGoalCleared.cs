using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGoalCleared : MonoBehaviour
{

    public GameObject shipPartWithRumble;
    public GameObject shipPartWithoutRumble;
    public GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        shipPartWithRumble.SetActive(false);
        shipPartWithoutRumble.SetActive(false);
        platform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("BallWithRumble")){
        shipPartWithRumble.SetActive(true);
        platform.SetActive(true);
      }

      if(other.CompareTag("BallWithoutRumble"))
      {
        shipPartWithoutRumble.SetActive(true);
      }  
    }
}
