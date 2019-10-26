using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager instance;
    // Start is called before the first frame update
    void Awake()
    {

        if (!instance)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var inputDevice = InputManager.ActiveDevice;


    }

    //public Vector3 Arrowkey(int index)
    //{

    //}
    //public Vector3 UpAndDown(int index)
    //{

    //}
    //public Vector3 Grab(int index)
    //{

    //}
}
