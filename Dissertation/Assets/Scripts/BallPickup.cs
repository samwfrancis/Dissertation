using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;

    List<Rigidbody> rgBalls = new List<Rigidbody>(); 

    public bool ballIsFollowing = false;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(ball.transform.position, player.transform.position); 

        if (Input.GetKeyDown(KeyCode.E))
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
            foreach(Rigidbody rgball in rgBalls)
            {
                rgball.AddForce((ball.transform.position - rgball.position) * 200f * Time.fixedDeltaTime);
            }
        }
        
    }
}
