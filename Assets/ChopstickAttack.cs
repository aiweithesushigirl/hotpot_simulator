using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ChopstickAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public InputDevice Device = InputManager.ActiveDevice;
    public Transform top;
    private Rigidbody rb;
    private bool canAttack;
    private bool isAttacking;


    void Start()
    {
        canAttack = true;
        isAttacking = false;
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if(obj.GetComponent<GeneralAction>() != null)
        {
            obj.GetComponent<GeneralAction>().doActionOne();
        }
    }
}
