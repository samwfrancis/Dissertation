using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float secondsElasped;

    public float windTime;
    private float magnetTime;
    private float boulderTime;

    public GameObject player;
    public GameObject shipPart1;
    public GameObject shipPart2;
    public GameObject shipPart3;

    public float windDistance;
    public float magnetDistance;
    public float boulderDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;

        windDistance = Vector3.Distance(shipPart3.transform.position, player.transform.position);
        magnetDistance = Vector3.Distance(shipPart2.transform.position, player.transform.position);
        boulderDistance = Vector3.Distance(shipPart1.transform.position, player.transform.position);

        if(windDistance < 3){
            if (Input.GetKeyDown(KeyCode.E)){
                windTime = secondsElasped;
            }
        }

    }

    public float GetWindTime(){
        return windTime;
    }

    public void SetWindTime(float inputTime){
        windTime = inputTime;
    } 




}
