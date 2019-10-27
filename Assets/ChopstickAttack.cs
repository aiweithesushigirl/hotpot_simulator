using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ChopstickAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public InputDevice Device = InputManager.ActiveDevice;
    private Chopsticks control;
    private GameObject interactingObject;
    private FoodBehavior fb;
    public Transform top;
    private Rigidbody rb;
    private bool canAttack;
    private bool isAttacking;


    void Start()
    {
        canAttack = true;
        isAttacking = false;
        control = GetComponent<Chopsticks>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = false;
        if (Device.Action3 && canAttack)
        {
            transform.RotateAround(top.position, Vector3.up, 10f);
            isAttacking = true;
        }
        if (Device.RightBumper)
        {
            interactingObject.GetComponent<GeneralAction>().doActionTwo();
            if(interactingObject.tag == "food")
            {
                canAttack = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.GetComponent<GeneralAction>() != null)
        {
            obj.GetComponent<GeneralAction>().doActionOne();
            interactingObject = obj;
        }
        if(obj.tag == "food")
        {
            canAttack = false;
        }
        if(obj.tag == "chopsticks")
        {

        }
    }

    IEnumerator stopAttack()
    {
        if (canAttack)
        {
            canAttack = false;
            yield return new WaitForSeconds(0.5f);
            canAttack = true;
        }
        else
        {
            interactingObject.GetComponent<GeneralAction>().doActionTwo();
            canAttack = true;
        }
    }
}
