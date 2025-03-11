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

    Vector3 pos = new Vector3(500,280,0);

    public Vector2 value = new Vector2(500,280);

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
        newPos = pos;
    }

    // Update is called once per frame
    void Update()
    {
        value = playerControls.ReadValue<Vector2>();
        newPos = new Vector3(newPos.x + value.x, newPos.y + value.y, 0);
        Ray ray = magnetCamera.ScreenPointToRay(newPos);
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
