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
                Vector3 magnetPosition = new Vector3(raycastHits[i].point.x, raycastHits[i].point.y + 2f, raycastHits[i].point.z);
                magnet.transform.position = magnetPosition;
            }
        } 
        
    }
}
