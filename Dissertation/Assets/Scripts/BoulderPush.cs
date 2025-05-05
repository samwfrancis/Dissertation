using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoulderPush : MonoBehaviour
{

    public float secondsElasped;
    public float boulderTimeWithRumbleStart;
    public float boulderTimeWithoutRumbleStart;
    public bool isRumble;

    private int timesPushedWithRumble = 0;
    private int timesPushedWithoutRumble = 0;

    public string path = Application.dataPath + "/Log.txt";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        secondsElasped = Time.time;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(isRumble)
            {
                if(timesPushedWithRumble <= 0)
            {
                boulderTimeWithRumbleStart = secondsElasped;
                string content = "Boulder With Rumble Start Time: " + boulderTimeWithRumbleStart + "\n";
                //File.AppendAllText(path, content);
            }
            timesPushedWithRumble += 1;
            }

            else if(!isRumble)
            {
                if(timesPushedWithoutRumble <= 0)
            {
                boulderTimeWithoutRumbleStart = secondsElasped;
                string content = "Boulder Without Rumble Start Time: " + boulderTimeWithoutRumbleStart + "\n";
                //File.AppendAllText(path, content);
            }
            timesPushedWithoutRumble += 1;
            }
        }
    }
}
