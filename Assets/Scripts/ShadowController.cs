using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public GameObject chopsticks;
    public Vector3 loc;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        loc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        loc.x = chopsticks.transform.position.x;
        loc.z = chopsticks.transform.position.z;
        
        Physics.Raycast(chopsticks.transform.position, transform.TransformDirection(Vector3.down), out hit);
        
        loc.y = chopsticks.transform.position.y - hit.distance;
        
        transform.position = loc;


    }
}
