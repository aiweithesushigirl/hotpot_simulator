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
    public Transform top;
    public float UpSpeed;
    
    public InputDevice Device = InputManager.ActiveDevice;
    private Rigidbody rb;
    public int playerIndex;
    public int point;
    private bool goingDown;
    private bool hasHit;

    void Start()
    {
		rb = GetComponent<Rigidbody>();
        goingDown = false;
        hasHit = false;
    }

    void Update()
    {
        if (Device != null)
        {
            bool down = Device.RightStickDown;
            bool up = Device.RightStickUp;
            Vector3 movement = new Vector3(Device.LeftStickX.Value, 0, Device.LeftStickY.Value);
            rb.velocity = movementSpeed * movement;
            if (Device.RightTrigger && !goingDown)
            {
                Debug.Log("Pushed down");
                goingDown = true;
                StartCoroutine(goDown());
                
            }
        }      
    }

    IEnumerator goDown()
    {
        while (!hasHit)
        {
            rb.AddForce(Vector3.down * 1000000);
            yield return null;
        }

        Vector3 start = transform.position;
        Vector3 dest = transform.position;
        dest.y = 20;
        float totalDist = Mathf.Abs(20 - start.y);
        float startTime = Time.time;
        while(transform.position.y != 20)
        {
            float distCovered = (Time.time - startTime) * UpSpeed;
            float fraction = distCovered / totalDist;
            transform.position = Vector3.Lerp(start, dest, fraction);
            yield return null;
        }
        
        transform.position = dest;
        goingDown = false;
        hasHit = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasHit = true;
    }
}
