using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class Timer : MonoBehaviour
{
    public string user;
    public float secondsElasped;

    public float windWithRumbleTimeComplete;
    public float windWithoutRumbleTimeComplete;
    public float magnetWithRumbleTimeComplete;
    public float magnetWithoutRumbleTimeComplete;
    public float boulderWithRumbleTimeComplete;
    public float boulderWithoutRumbleTimeComplete;

    public GameObject player;
    public GameObject shipPart1;
    public GameObject shipPart2;
    public GameObject shipPart3;
    public GameObject shipPart4;
    public GameObject shipPart5;
    public GameObject shipPart6;

    public GameObject popUp1;
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;
    public GameObject popUp5;
    public GameObject popUp6;

    public float windWithRumbleDistance;
    public float windWithoutRumbleDistance;
    public float magnetWithRumbleDistance;
    public float magnetWithoutRumbleDistance;
    public float boulderWithRumbleDistance;
    public float boulderWithoutRumbleDistance;

    public string path = Application.dataPath + "/Log.txt";

    Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        CreateText();
        popUp1.SetActive(false);
        popUp2.SetActive(false);
        popUp3.SetActive(false);
        popUp4.SetActive(false);
        popUp5.SetActive(false);
        popUp6.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;
        if (shipPart1 != null){
            magnetWithRumbleDistance = Vector3.Distance(shipPart1.transform.position, player.transform.position);

            if (magnetWithRumbleDistance > 5) popUp1.SetActive(false);
            if (magnetWithRumbleDistance < 5) popUp1.SetActive(true);
            if (magnetWithRumbleDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                magnetWithRumbleTimeComplete = secondsElasped;
                string content = "Magnet with rumble completion time: " + magnetWithRumbleTimeComplete + "\n";
                //File.AppendAllText(path, content);
                Destroy(shipPart1);
                popUp1.SetActive(false);
            }
        }
        }

        if (shipPart2 != null){
            boulderWithRumbleDistance = Vector3.Distance(shipPart2.transform.position, player.transform.position);

            if (boulderWithRumbleDistance > 5) popUp2.SetActive(false);
            if (boulderWithRumbleDistance < 5) popUp2.SetActive(true);
            if (boulderWithRumbleDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                boulderWithRumbleTimeComplete = secondsElasped;
                string content = "Boulder with rumble completion time: " + boulderWithRumbleTimeComplete + "\n";
                //File.AppendAllText(path, content);
                Destroy(shipPart2);
                popUp2.SetActive(false);
                }
            }
        }

        if (shipPart6 != null){
            boulderWithoutRumbleDistance = Vector3.Distance(shipPart6.transform.position, player.transform.position);

            if (boulderWithoutRumbleDistance > 5) popUp6.SetActive(false);
            if (boulderWithoutRumbleDistance < 5) popUp6.SetActive(true);
            if (boulderWithoutRumbleDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                boulderWithoutRumbleTimeComplete = secondsElasped;
                string content = "Boulder without rumble completion time: " + boulderWithoutRumbleTimeComplete + "\n";
                //File.AppendAllText(path, content);
                Destroy(shipPart6);
                popUp6.SetActive(false);
                }
            }
        }

        if (shipPart3 != null){
            windWithRumbleDistance = Vector3.Distance(shipPart3.transform.position, player.transform.position);

            if (windWithRumbleDistance > 5) popUp3.SetActive(false);
            if (windWithRumbleDistance < 5) popUp3.SetActive(true);
             if(windWithRumbleDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                windWithRumbleTimeComplete = secondsElasped;
                string content = "Wind with rumble completion time: " + windWithRumbleTimeComplete + "\n";
                //File.AppendAllText(path, content);
                Destroy(shipPart3);
                popUp3.SetActive(false);
                }
            }
        }

        if (shipPart5 != null){
            windWithoutRumbleDistance = Vector3.Distance(shipPart5.transform.position, player.transform.position);

            if (windWithoutRumbleDistance > 5) popUp5.SetActive(false);
            if (windWithoutRumbleDistance < 5) popUp5.SetActive(true);
             if(windWithoutRumbleDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                windWithoutRumbleTimeComplete = secondsElasped;
                string content = "Wind without rumble completion time: " + windWithoutRumbleTimeComplete + "\n";
                //File.AppendAllText(path, content);
                Destroy(shipPart5);
                popUp5.SetActive(false);
                }
            }
        }


        if (shipPart4 != null){
            magnetWithoutRumbleDistance = Vector3.Distance(shipPart4.transform.position, player.transform.position);

            if (magnetWithoutRumbleDistance > 5) popUp4.SetActive(false);
            if (magnetWithoutRumbleDistance < 5) popUp4.SetActive(true);
            if (magnetWithoutRumbleDistance < 5){
                if (gamepad.buttonWest.wasPressedThisFrame){
                magnetWithoutRumbleTimeComplete = secondsElasped;
                string content = "Magnet without rumble completion time: " + magnetWithRumbleTimeComplete + "\n";
                //File.AppendAllText(path, content);
                Destroy(shipPart4);
                popUp4.SetActive(false);
            }
        }
        }

        if (magnetWithRumbleTimeComplete > 0 && boulderWithRumbleTimeComplete > 0 && windWithRumbleTimeComplete > 0 && magnetWithoutRumbleTimeComplete > 0 && boulderWithoutRumbleTimeComplete > 0 && windWithoutRumbleTimeComplete > 0)
        {
            Debug.Log("You Win !");
        }
    }

    void CreateText()
    {

        /*if(!File.Exists(path))
        {
            File.WriteAllText(path, "Time Log \n\n");
        }

        string content = "User: " + user + "\n";

        File.AppendAllText(path, content);*/
    }

}
