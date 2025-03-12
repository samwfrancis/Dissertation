using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BoulderPush : MonoBehaviour
{

    public float secondsElasped;
    public float boulderTimeStart;

    private int timesPushed = 0;

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
            if(timesPushed <= 0)
            {
                boulderTimeStart = secondsElasped;
                string content = "Boulder Start Time: " + boulderTimeStart + "\n";
                File.AppendAllText(path, content);
            }
            timesPushed += 1;
        }
    }
}
