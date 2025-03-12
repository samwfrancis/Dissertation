using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMagnetSwap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject magnetPoint;
    [SerializeField] private GameObject magnet;

    [SerializeField] private GameObject magnetCamera;
    [SerializeField] private GameObject playerCamera;
    
    [SerializeField] private GameObject playerLocation;

    public GameObject popUp;

    public float secondsElasped;
    public float magnetTimeStart;
    private int numberSwitched = 0;

    private bool isMagnetActive = false; // Track whether the magnet is currently active or not.

    public float distance;


    //private StarterAssetsInputs _input;

    Gamepad gamepad = Gamepad.current;
    

    
    // Start is called before the first frame update
    void Start()
    {
        // Initial setup if needed
        //_input = GetComponent<StarterAssetsInputs>();
        popUp.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        secondsElasped = Time.time;
        distance = Vector3.Distance(magnet.transform.position , playerLocation.transform.position);

        if (distance > 5) popUp.SetActive(false);

        if (distance < 5) popUp.SetActive(true);
        
            
        if (gamepad.buttonWest.wasPressedThisFrame) // Check if the "E" key is pressed
        {
            if (isMagnetActive)
            {
                // Switch back to the player
                player.SetActive(true);
                magnetPoint.SetActive(false);
                playerCamera.SetActive(true); // Assuming you have the player's camera
                magnetCamera.SetActive(false);
                magnet.transform.position = new Vector3(276.15f, 2.6f, 35.11f);
            }
            else if (distance < 5)
            {
                // Switch to the magnet
                player.SetActive(false);
                magnetPoint.SetActive(true);
                playerCamera.SetActive(false);
                magnetCamera.SetActive(true);
                if(numberSwitched <= 0)
                {
                    magnetTimeStart = secondsElasped;
                }
                numberSwitched =+ 1;
            }

            // Toggle the state
            isMagnetActive = !isMagnetActive;
        }
    }
}

