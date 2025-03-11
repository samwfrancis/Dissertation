using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Timer : MonoBehaviour
{
    public float secondsElasped;

    public float windTime;
    public float magnetTime;
    public float boulderTime;

    public GameObject player;
    public GameObject shipPart1;
    public GameObject shipPart2;
    public GameObject shipPart3;

    public float windDistance;
    public float magnetDistance;
    public float boulderDistance;

    Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;
        if (shipPart1 != null){
            magnetDistance = Vector3.Distance(shipPart1.transform.position, player.transform.position);
            if (magnetDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                magnetTime = secondsElasped;
                Destroy(shipPart1);
            }
        }
        }

        if (shipPart2 != null){
            boulderDistance = Vector3.Distance(shipPart2.transform.position, player.transform.position);
            if (boulderDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                boulderTime = secondsElasped;
                Destroy(shipPart2);
                }
            }
        }

        if (shipPart3 != null){
            windDistance = Vector3.Distance(shipPart3.transform.position, player.transform.position);
             if(windDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                windTime = secondsElasped;
                Destroy(shipPart3);
                }
            }
        }

        if (magnetTime > 0 && boulderTime > 0 && windTime > 0)
        {
            Debug.Log("You Win !");
        }
    }

    public float GetWindTime(){
        return windTime;
    }

    public void SetWindTime(float inputTime){
        windTime = inputTime;
    } 




}
