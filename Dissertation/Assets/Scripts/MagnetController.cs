using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private Camera magnetCamera;
    public GameObject magnet;

    public InputAction playerControls;

    public Vector3 mousePos;

    public Vector3 newPos; 

    Vector3 pos = new Vector3(280,2,40);

    public bool isRumble;

    public Vector2 rumbleValue = new Vector2(280,40);
    public Vector2 WithoutRumbleValue = new Vector2(280, 80);
    public Vector2 value;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable(){
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        if(!isRumble)
        {
            newPos = new Vector3(280,2,80);
        }
        else
        {
            newPos = new Vector3(280,2,40);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRumble)
        {
            value = WithoutRumbleValue;
            
        }
        else{
            value = rumbleValue;
        }

        
        value = playerControls.ReadValue<Vector2>();
        newPos = new Vector3(newPos.x + (value.x * 0.005f), 2, newPos.z + (value.y * 0.005f));
        /*Ray ray = magnetCamera.ScreenPointToRay(newPos);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);
        for (int i = 0; i < raycastHits.Length; i++)
        {
            if(raycastHits[i].collider.tag != "Magnet")
            {
                Vector3 magnetPosition = new Vector3(raycastHits[i].point.x, raycastHits[i].point.y + 2f, raycastHits[i].point.z);
                magnet.transform.position = magnetPosition;
            }
        }*/

        magnet.transform.position = newPos;
        
    }
}
