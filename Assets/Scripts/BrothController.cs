using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrothController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            other.gameObject.GetComponent<FoodBehavior>().isCooking = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "food")
        {
            other.gameObject.GetComponent<FoodBehavior>().isCooking = false;
        }
    }
}
