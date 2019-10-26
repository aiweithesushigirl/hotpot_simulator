using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class Chopsticks : MonoBehaviour
{
	public float movementSpeed = 2.0f;
    public int playerNumber;
    public GameObject bowl;
    public GameObject gameController;
    public GameObject foodObject;
    public GameObject tip;
    
    public InputDevice Device = InputManager.ActiveDevice;
    private Rigidbody rb;
    public int playerIndex;
    public int point;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        if (Device != null)
        {
            bool down = Device.RightStickDown;
            bool up = Device.RightStickUp;
            Vector3 movement = new Vector3(Device.LeftStickX.Value, (down ? -1 : 0) + (up ? 1 : 0), Device.LeftStickY.Value);
            rb.velocity = movementSpeed * movement;
        }
        //temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray))
        //this.transform.position = Camera.main.ScreenToWorldPoint(temp);
        //rb.velocity = movementSpeed * movement;


        //float move_x = Input.GetAxis("Horizontal");
        //float move_y = Input.GetAxis("Vertical");
        //      Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //      Vector3 movement = new Vector3(mousePosition.x, mousePosition.y, (down ? -1 : 0) + (up ? 1 : 0));
        //      //Input.mousePosition;

    }
}
