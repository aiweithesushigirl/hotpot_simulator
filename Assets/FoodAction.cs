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
        fb.grabbed = !fb.grabbed;
    }

    public override void doActionTwo()
    {
        
    }
}
