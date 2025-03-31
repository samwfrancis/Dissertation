using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class PlayerMagnetSwap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject magnetPointWithRumble;
    [SerializeField] private GameObject magnetPointWithoutRumble;
    [SerializeField] private GameObject magnetWithRumble;
    [SerializeField] private GameObject magnetWithoutRumble;

    [SerializeField] private GameObject magnetCameraWithRumble;
    [SerializeField] private GameObject magnetCameraWithoutRumble;
    [SerializeField] private GameObject playerCamera;
    
    [SerializeField] private GameObject playerLocation;

    public GameObject popUpWithRumble;
    public GameObject popUpWithoutRumble;

    public float secondsElasped;
    public float magnetTimeStartWithRumble;
    public float magnetTimeStartWithoutRumble;
    private int numberSwitchedWithRumble = 0;
    private int numberSwitchedWithoutRumble = 0;

    private bool isMagnetWithRumbleActive = false; // Track whether the magnet is currently active or not.
    private bool isMagnetWithoutRumbleActive = false;

    public float distanceWithRumble;
    public float distanceWithoutRumble;

    public string path = Application.dataPath + "/Log.txt";


    //private StarterAssetsInputs _input;

    Gamepad gamepad = Gamepad.current;
    

    
    // Start is called before the first frame update
    void Start()
    {
        // Initial setup if needed
        //_input = GetComponent<StarterAssetsInputs>();
        popUpWithoutRumble.SetActive(false);
        popUpWithRumble.SetActive(false);
            
    }

    // Update is called once per frame
    void Update()
    {

        secondsElasped = Time.time;
        distanceWithRumble = Vector3.Distance(magnetWithRumble.transform.position , playerLocation.transform.position);
        distanceWithoutRumble = Vector3.Distance(magnetWithoutRumble.transform.position , playerLocation.transform.position);

        if (distanceWithRumble > 5) popUpWithRumble.SetActive(false);
        if (distanceWithRumble < 5) popUpWithRumble.SetActive(true);

        if (distanceWithoutRumble > 5) popUpWithoutRumble.SetActive(false);
        if (distanceWithoutRumble < 5) popUpWithoutRumble.SetActive(true);
        
            
        if (gamepad.buttonWest.wasPressedThisFrame) // Check if the "E" key is pressed
        {
            if (isMagnetWithRumbleActive)
            {
                // Switch back to the player
                player.SetActive(true);
                magnetPointWithRumble.SetActive(false);
                playerCamera.SetActive(true); // Assuming you have the player's camera
                magnetCameraWithRumble.SetActive(false);
                magnetWithRumble.transform.position = new Vector3(276.15f, 2.6f, 35.11f);
                Gamepad.current.SetMotorSpeeds(0,0);
            }
            else if (distanceWithRumble < 5)
            {
                // Switch to the magnet
                player.SetActive(false);
                magnetPointWithRumble.SetActive(true);
                magnetWithRumble.transform.position = new Vector3(285.15f, 2.6f, 66.11f);
                playerCamera.SetActive(false);
                magnetCameraWithRumble.SetActive(true);
                if(numberSwitchedWithRumble <= 0)
                {
                    magnetTimeStartWithRumble = secondsElasped;
                    string content = "Magnet Start Time: " + magnetTimeStartWithRumble + "\n";
                    File.AppendAllText(path, content);
                }
                numberSwitchedWithRumble =+ 1;
            }

            // Toggle the state
            isMagnetWithRumbleActive = !isMagnetWithRumbleActive;


            if (isMagnetWithoutRumbleActive)
            {
                // Switch back to the player
                player.SetActive(true);
                magnetPointWithoutRumble.SetActive(false);
                playerCamera.SetActive(true); // Assuming you have the player's camera
                magnetCameraWithoutRumble.SetActive(false);
                magnetWithoutRumble.transform.position = new Vector3(276.15f, 2.6f, 77f);
            }
            else if (distanceWithoutRumble < 5)
            {
                // Switch to the magnet
                player.SetActive(false);
                magnetPointWithoutRumble.SetActive(true);
                magnetWithoutRumble.transform.position = new Vector3(280.15f, 2.6f, 82f);
                playerCamera.SetActive(false);
                magnetCameraWithoutRumble.SetActive(true);
                if(numberSwitchedWithoutRumble <= 0)
                {
                    magnetTimeStartWithoutRumble = secondsElasped;
                    string content = "Magnet Start Time: " + magnetTimeStartWithoutRumble + "\n";
                    File.AppendAllText(path, content);
                }
                numberSwitchedWithoutRumble =+ 1;
            }

            // Toggle the state
            isMagnetWithoutRumbleActive = !isMagnetWithoutRumbleActive;
        }
    }

}

