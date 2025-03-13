using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class Timer : MonoBehaviour
{
    public string user;
    public float secondsElasped;

    public float windTimeComplete;
    public float magnetWithRumbleTimeComplete;
    public float magnetWithoutRumbleTimeComplete;
    public float boulderTimeComplete;

    public GameObject player;
    public GameObject shipPart1;
    public GameObject shipPart2;
    public GameObject shipPart3;
    public GameObject shipPart4;

    public GameObject popUp1;
    public GameObject popUp2;
    public GameObject popUp3;
    public GameObject popUp4;

    public float windDistance;
    public float magnetWithRumbleDistance;
    public float magnetWithoutRumbleDistance;
    public float boulderDistance;

    public string path = Application.dataPath + "/Log.txt";

    Gamepad gamepad = Gamepad.current;
    // Start is called before the first frame update
    void Start()
    {
        CreateText();
        popUp1.SetActive(false);
        popUp2.SetActive(false);
        popUp3.SetActive(false);
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
                File.AppendAllText(path, content);
                Destroy(shipPart1);
                popUp1.SetActive(false);
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
                string content = "Boulder completion time: " + boulderTimeComplete + "\n";
                File.AppendAllText(path, content);
                Destroy(shipPart2);
                popUp2.SetActive(false);
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
                string content = "Wind completion time: " + windTimeComplete + "\n";
                File.AppendAllText(path, content);
                Destroy(shipPart3);
                popUp3.SetActive(false);
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
                File.AppendAllText(path, content);
                Destroy(shipPart4);
                popUp4.SetActive(false);
            }
        }
        }

        if (magnetWithRumbleTimeComplete > 0 && boulderTimeComplete > 0 && windTimeComplete > 0 && magnetWithoutRumbleTimeComplete > 0)
        {
            Debug.Log("You Win !");
        }
    }

    void CreateText()
    {

        if(!File.Exists(path))
        {
            File.WriteAllText(path, "Time Log \n\n");
        }

        string content = "User: " + user + "\n";

        File.AppendAllText(path, content);
    }

}
