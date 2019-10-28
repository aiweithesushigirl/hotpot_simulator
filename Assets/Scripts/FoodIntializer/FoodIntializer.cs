using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodIntializer : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        FoodBehavior fb = GetComponent<FoodBehavior>();
        fb.gameController = GameObject.Find("GameController");
        fb.slider = GameObject.Find("Slider");
        fb.overcooked = GameObject.Find("Overcooked").GetComponent<OvercookedDisplayer>();
    }
}
