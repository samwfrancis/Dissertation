using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class BallPickup : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;

    public GameObject popUp;
    public float secondsElasped;
    public float windTimeStart;
    private int numberSwitched = 0;

    Rigidbody ballrb;

    public bool ballIsFollowing = false;

    public float distance;

    public string path = Application.dataPath + "/Log.txt";
    // Start is called before the first frame update
    void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;
        distance = Vector3.Distance(ball.transform.position, player.transform.position);

        if(distance > 2) popUp.SetActive(false);
        if (distance < 2) popUp.SetActive(true);
        if (Gamepad.current.buttonWest.wasPressedThisFrame)
            if(ballIsFollowing)
            {
                ballIsFollowing = false;
            }
            else if (distance < 2){
                ballIsFollowing = true;
                if(numberSwitched <= 0)
                {
                    windTimeStart = secondsElasped;
                    string content = "Wind Start Time: " + windTimeStart + "\n";
                    File.AppendAllText(path, content);
                }
                numberSwitched += 1;
            }
           
    }

    void FixedUpdate()
    {
        if (ballIsFollowing)
        {
                ballrb.AddForce((player.transform.position - ballrb.position) * 200f * Time.fixedDeltaTime);
            
        }
        
    }
}
