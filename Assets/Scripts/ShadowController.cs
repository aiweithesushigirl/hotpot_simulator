using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public GameObject tip;
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
        loc.x = tip.transform.position.x;
        loc.z = tip.transform.position.z;
        
        Physics.Raycast(tip.transform.position, Vector3.down, out hit);
        
        loc.y = tip.transform.position.y - hit.distance;
        
        transform.position = loc;
        //transform.eulerAngles = Vector3.zero;

    }
}
