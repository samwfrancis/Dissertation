using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private Camera magnetCamera;
    public GameObject magnet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = magnetCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        for (int i = 0; i < raycastHits.Length; i++)
        {
            if(raycastHits[i].collider.tag != "Magnet")
            {
                magnet.transform.position = raycastHits[i].point;
            }
        } 
        
    }
}
