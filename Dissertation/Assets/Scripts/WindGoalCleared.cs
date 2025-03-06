using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindGoalCleared : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Ball")){
        anim.SetTrigger("EnterGoal");
      }  
    }
}
