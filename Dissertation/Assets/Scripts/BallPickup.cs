using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject player;

    public bool ballIsChild = false;

    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, ball.transform.position); 

        if (Input.GetKeyDown(KeyCode.E))
            if(ballIsChild)
            {
                ball.transform.SetParent(null);
                ballIsChild = false;
            }
            else if (distance < 2){
                ball.transform.SetParent(ball.transform);
                ballIsChild = true;
            }
           
    }
}
