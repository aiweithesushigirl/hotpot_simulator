using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAction : GeneralAction
{
    FoodBehavior fb;
    private void Start()
    {
        fb = GetComponent<FoodBehavior>();
    }

    public override void doActionOne()
    {
        fb.grabbed = true;
    }

    public override void doActionTwo()
    {
        fb.grabbed = false;
    }
}
