using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallPickup : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;

    Rigidbody ballrb;

    public bool ballIsFollowing = false;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(ball.transform.position, player.transform.position); 

        if (Gamepad.current.buttonWest.wasPressedThisFrame)
            if(ballIsFollowing)
            {
                ballIsFollowing = false;
            }
            else if (distance < 2){
                ballIsFollowing = true;
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
