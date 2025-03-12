using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public float secondsElasped;

    public float windTimeComplete;
    public float magnetTimeComplete;
    public float magnetTimeStart;
    public float boulderTimeComplete;
    public float boulderTimeStart;

    public GameObject player;
    public GameObject shipPart1;
    public GameObject shipPart2;
    public GameObject shipPart3;

    public GameObject popUp1;
    public GameObject popUp2;
    public GameObject popUp3;

    public float windDistance;
    public float magnetDistance;
    public float boulderDistance;

    Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        popUp1.SetActive(false);
        popUp2.SetActive(false);
        popUp3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;
        if (shipPart1 != null){
            magnetDistance = Vector3.Distance(shipPart1.transform.position, player.transform.position);

            if (magnetDistance > 5) popUp1.SetActive(false);
            if (magnetDistance < 5) popUp1.SetActive(true);
            if (magnetDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                magnetTimeComplete = secondsElasped;
                Destroy(shipPart1);
            }
        }
        }

        if (shipPart2 != null){
            boulderDistance = Vector3.Distance(shipPart2.transform.position, player.transform.position);

            if (boulderDistance > 5) popUp2.SetActive(false);
            if (boulderDistance < 5) popUp2.SetActive(true);
            if (boulderDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                boulderTimeComplete = secondsElasped;
                Destroy(shipPart2);
                }
            }
        }

        if (shipPart3 != null){
            windDistance = Vector3.Distance(shipPart3.transform.position, player.transform.position);

            if (windDistance > 5) popUp3.SetActive(false);
            if (windDistance < 5) popUp3.SetActive(true);
             if(windDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                windTimeComplete = secondsElasped;
                Destroy(shipPart3);
                }
            }
        }

        if (magnetTimeComplete > 0 && boulderTimeComplete > 0 && windTimeComplete > 0)
        {
            Debug.Log("You Win !");
        }
    }

}
